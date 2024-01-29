using Gestion_de_tareas.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gestion_de_tareas
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new VListado());
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
