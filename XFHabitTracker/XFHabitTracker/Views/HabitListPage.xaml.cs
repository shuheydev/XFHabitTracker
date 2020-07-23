using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFHabitTracker.Models;
using XFHabitTracker.Services;
using XFHabitTracker.ViewModels;

namespace XFHabitTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HabitListPage : ContentPage
    {
        private readonly HabitListViewModel _viewModel;

        public HabitListPage()
        {
            InitializeComponent();

            var a = Startup.ServiceProvider.GetService<IDataStore<Habit>>();

            this.BindingContext =_viewModel= Startup.ServiceProvider.GetService<HabitListViewModel>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await _viewModel.UpdateList();
        }

        private async void AddHabitButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AddHabitPage));
        }
    }
}