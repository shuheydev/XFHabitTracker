using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFHabitTracker.Models;

namespace XFHabitTracker.Services
{
    public class DataStoreMock : IDataStore<Habit>
    {
        public Task<string> AddItemAsync(Habit item)
        {
            throw new NotImplementedException();
        }

        public bool Clear()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Habit> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Habit>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateItemAsync(Habit item)
        {
            throw new NotImplementedException();
        }
    }
}
