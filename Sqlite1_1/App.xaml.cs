using Sqlite1_1.Repositories;
using Sqlite1_1.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sqlite1_1
{
    public partial class App : Application
    {
        #region Repository
        private static ContactoRepositorio _ContactoDb;
        public static ContactoRepositorio ContactoDb
        {
            get
            {
                if(_ContactoDb == null)
                {
                    _ContactoDb = new ContactoRepositorio();
                }
                return _ContactoDb;
            }
        }
        private static ActaNacimientoRepository _ActaNacimientoDb;

        public static ActaNacimientoRepository ActaNacimientoDb
        {
            get
            {
                if (_ActaNacimientoDb == null)
                {
                    _ActaNacimientoDb = new ActaNacimientoRepository();
                }
                return _ActaNacimientoDb;
            }
        }

        private static TelefonoRepository _TelefonosDb;
        public static TelefonoRepository TelefonosDb
        {
            get
            {
                if (_TelefonosDb == null)
                {
                    _TelefonosDb = new TelefonoRepository();
                }
                return _TelefonosDb;
            }
        }

        #endregion


        public App()
        {

            InitializeComponent();
            //Siempre crear primero las tablas hijas
            ActaNacimientoDb.Init();
            TelefonosDb.Init();
            ContactoDb.Init();

            MainPage = new NavigationPage(new Inicio());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
