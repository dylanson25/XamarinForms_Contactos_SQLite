using Bogus;
using Sqlite1_1.Model;
using Sqlite1_1.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Sqlite1_1.ViewModel
{
    public class MttoContactoViewModel: BaseViewModel
    {
        public ICommand cmdGrabaContacto { get; set; }
        public ICommand cmdAgregaTelefono { get; set; }
        public ICommand cmdEliminaTelefono { get; set; }
        public Contacto Contacto { get; set; }
        

        public MttoContactoViewModel(Contacto contacto)
        {
            Contacto = contacto;

            if (Contacto.Telefonos == null)
            {
                Contacto.Telefonos = new System.Collections.ObjectModel.ObservableCollection<Telefono>();
            }

            cmdGrabaContacto = new Command<Contacto>((item) => cmdGrabaContactoMetodo(item));
            cmdAgregaTelefono = new Command(() => cmdAgregaTelefonoMetodo());
            cmdEliminaTelefono = new Command<Telefono>((telefono) => cmdEliminaTelefonoTelefonoMetodo(telefono)); 
        }

        private void cmdEliminaTelefonoTelefonoMetodo(Telefono telefono)
        {
            Contacto.Telefonos.Remove(telefono);
            OnPropertyChanged();
        }

        private void cmdAgregaTelefonoMetodo()
        {
         
            temp telefono = new Faker<temp>().RuleFor(c => c.telefono, f => f.Phone.PhoneNumber()).Generate();

            if (Contacto.Telefonos == null)
            {
                Contacto.Telefonos = new System.Collections.ObjectModel.ObservableCollection<Telefono>();
            }
            Contacto.Telefonos.Add(new Telefono() { Numero = telefono.telefono });

            OnPropertyChanged();
        }
        class temp
        {
            public string telefono { get; set; }
        }

        private void cmdGrabaContactoMetodo(Contacto contacto)
        {
            App.ContactoDb.InsertOrUpdate(contacto);
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
