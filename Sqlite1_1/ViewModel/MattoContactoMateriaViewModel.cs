using Sqlite1_1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Sqlite1_1.ViewModel
{
    public class MattoContactoMateriaViewModel : BaseViewModel
    {

        public Contacto Contacto { get; set; }
        public ObservableCollection<Materia> Materias { get; set; }


        public ICommand cmdGrabaContacto { get; set; }
        public ICommand cmdAgregaMateria { get; set; }

        public ICommand cmdMattoEliminaTelefono { get; set; }
        public MattoContactoMateriaViewModel(Contacto contacto)
        {

            Contacto = contacto;

            if (Contacto.Telefonos == null)
            {
                Contacto.Telefonos = new ObservableCollection<Telefono>();
            }


            if (Contacto.Materias == null)
            {
                Contacto.Materias = new ObservableCollection<Materia>();
            }




            Materias = new ObservableCollection<Materia>(App.MateriasDb.GetAll());



            cmdGrabaContacto = new Command<Contacto>((item) => cmdGrabaContactoMetodo(item));
            cmdAgregaMateria = new Command(() => cmdAgregaMateriaMetodo());
            cmdMattoEliminaTelefono = new Command<Telefono>((item) => cmdMattoEliminaTelefonoMetodo(item));


        }

        private void cmdMattoEliminaTelefonoMetodo(Telefono telefono)
        {
            Contacto.Telefonos.Remove(telefono);
            OnPropertyChanged();
        }

        private void cmdAgregaMateriaMetodo()
        {

            if (Contacto.Materias == null)
            {
                Contacto.Materias = new ObservableCollection<Materia>();

            }
            Contacto.Materias.Add(new Materia() { Nombre = Materias[Aleatorio()].Nombre });
            OnPropertyChanged();

        }

        private int Aleatorio()
        {
            int totalItemMaterias = Materias.Count - 1;
            Random rnd = new Random();

            int index = rnd.Next(1, 32000) % totalItemMaterias;
            return index;


        }
        class temp
        {

            public string Nombre { get; set; }
        }

        private void cmdGrabaContactoMetodo(Contacto contacto)
        {
            App.ContactoDb.InsertOrUpdate(contacto);
            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
