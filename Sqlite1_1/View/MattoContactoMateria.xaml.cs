using Sqlite1_1.Model;
using Sqlite1_1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sqlite1_1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MattoContactoMateria : ContentPage
    {
        public MattoContactoMateria(Contacto contacto)
        {
            InitializeComponent();
            BindingContext = new MattoContactoMateriaViewModel(contacto);
        }
    }
}