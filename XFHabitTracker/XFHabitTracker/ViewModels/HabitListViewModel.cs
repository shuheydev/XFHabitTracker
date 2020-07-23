using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFHabitTracker.Models;
using XFHabitTracker.Services;

namespace XFHabitTracker.ViewModels
{
    [QueryProperty(nameof(HabitId), "habitId")]
    [QueryProperty(nameof(ActionType), "actionType")]
    public class HabitListViewModel : BaseViewModel
    {
        private string _habitId = string.Empty;
        public string HabitId
        {
            get => _habitId;
            set
            {
                SetProperty(ref _habitId, Uri.UnescapeDataString(value ?? string.Empty));
            }
        }

        private string _actionType = string.Empty;
        public string ActionType
        {
            get => _actionType;
            set
            {
                SetProperty(ref _actionType, Uri.UnescapeDataString(value ?? string.Empty));
            }
        }

        private ObservableRangeCollection<Habit> _habits = new ObservableRangeCollection<Habit>();
        public ObservableRangeCollection<Habit> Habits
        {
            get => _habits;
            set => SetProperty(ref _habits, value);
        }

        private readonly IDataStore<Habit> _dataService;
        public HabitListViewModel(IDataStore<Habit> dataService)
        {
            this._dataService = dataService;

            var habits = _dataService.GetItemsAsync().GetAwaiter().GetResult();
            Habits.AddRange(habits);
        }

        public async Task UpdateList()
        {
            switch (ActionType)
            {
                case "add":
                    {
                        var habit = await _dataService.GetItemAsync(HabitId);
                        Habits.Insert(0, habit);
                        break;
                    }
            }
        }

        public ICommand ClearAllHabitsCommand => new AsyncCommand(ClearAllHabits);
        private async Task ClearAllHabits()
        {
            Habits.Clear();
            _dataService.Clear();
        }
    }
}
