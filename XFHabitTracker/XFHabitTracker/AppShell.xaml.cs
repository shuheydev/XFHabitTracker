using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFHabitTracker.Views;

namespace XFHabitTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddHabitPage), typeof(AddHabitPage));
            Routing.RegisterRoute(nameof(HabitListPage), typeof(HabitListPage));
        }
    }
}