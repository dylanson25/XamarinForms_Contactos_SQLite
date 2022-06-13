using Sqlite1_1.Model;
using Sqlite1_1.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Sqlite1_1.ViewModel
{
    public class MttoContactoViewModel
    {
        public ICommand cmdGrabaContacto { get; set; }
        public Contacto Contacto { get; set; }

        public MttoContactoViewModel(Contacto contacto)
        {
            Contacto = contacto;
            cmdGrabaContacto = new Command<Contacto>((item) => cmdGrabaContactoMetodo(item)); 
        }

        private void cmdGrabaContactoMetodo(Contacto contacto)
        {
            App.ContactoDb.InsertOrUpdate(contacto);
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
