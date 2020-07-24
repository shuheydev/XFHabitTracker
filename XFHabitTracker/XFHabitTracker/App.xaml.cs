using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFHabitTracker
{
    public partial class App : Application
    {
        public App()
        {
            Device.SetFlags(new string[] {"Markup_Experimental" });

            InitializeComponent();

            MainPage = Startup.ServiceProvider.GetService<Shell>();
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
