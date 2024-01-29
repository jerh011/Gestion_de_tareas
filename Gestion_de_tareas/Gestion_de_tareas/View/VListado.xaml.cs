using Gestion_de_tareas.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gestion_de_tareas.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VListado : ContentPage
    {
        VMListado vM;
        public VListado()
        {
                InitializeComponent();
                vM = new VMListado(Navigation);
                BindingContext = vM;
                this.Appearing += Lista_Appearing; 
        }

            //desactivarlo cuando este usando la aplicacion en tiempo real
            private async void Lista_Appearing(object sender, EventArgs e)
            {
                await vM.Mostrar();
            }
        }
    }