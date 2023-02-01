using PasarSQLFirebase.Vistas;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PasarSQLFirebase
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Usuarios();
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
