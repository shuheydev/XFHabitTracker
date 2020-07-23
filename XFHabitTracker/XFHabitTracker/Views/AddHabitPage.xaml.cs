using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFHabitTracker.ViewModels;

namespace XFHabitTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddHabitPage : ContentPage
    {
        private readonly object _viewModel;

        public AddHabitPage()
        {
            InitializeComponent();

            this.BindingContext = _viewModel = Startup.ServiceProvider.GetService<AddHabitViewModel>();
        }
    }
}