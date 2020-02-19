using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarac
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MorsePage();
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
