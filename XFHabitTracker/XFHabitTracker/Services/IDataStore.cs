using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XFHabitTracker.Models;

namespace XFHabitTracker.Services
{
    public interface IDataStore<T> where T : class
    {
        Task<string> AddItemAsync(T item);
        Task<string> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
        bool Save();
        bool Clear();
    }
}
