using MvvmHelpers.Commands;
using Syncfusion.DataSource.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFHabitTracker.Models;
using XFHabitTracker.Services;
using System.Linq;
using MvvmHelpers;

namespace XFHabitTracker.ViewModels
{
    public class AddHabitViewModel : BaseViewModel
    {
        private readonly IDataStore<Habit> _dataService;

        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public ICommand AddNewHabitCommand => new AsyncCommand(AddNewHabit);

        private async Task AddNewHabit()
        {
            var newHabit = new Habit
            {
                Name = this.Name,
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTimeOffset.Now,
            };
            var addedHabitId = await _dataService.AddItemAsync(newHabit);

            await Shell.Current.GoToAsync($"..?habitId={addedHabitId}&actionType=add");
        }

        public AddHabitViewModel(IDataStore<Habit> dataService)
        {
            this._dataService = dataService;
        }
    }
}
