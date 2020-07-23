using Syncfusion.DataSource.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using Xamarin.Essentials;
using XFHabitTracker.Models;

namespace XFHabitTracker.Services
{
    public class HabitStore : IDataStore<Habit>
    {
        private readonly string _fileName = "Habits.json";
        private readonly string _filePath = string.Empty;

        private List<Habit> _items = new List<Habit>();

        public HabitStore()
        {
            this._filePath = Path.Combine(FileSystem.AppDataDirectory, _fileName);

            InitHabits();
        }

        private void InitHabits()
        {
            if (!File.Exists(_filePath))
            {
                Save();
                return;
            }

            string json = File.ReadAllText(_filePath);

            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    ReadCommentHandling = JsonCommentHandling.Skip
                };

                _items = JsonSerializer.Deserialize<List<Habit>>(json, options);
            }
            catch
            {
                Save();
            }
        }

        public async Task<string> AddItemAsync(Habit item)
        {
            _items.Add(item);
            Save();

            return await Task.FromResult(item.Id);
        }

        public async Task<string> UpdateItemAsync(Habit item)
        {
            var target = _items.FirstOrDefault(h => h.Id == item.Id);
            int index = _items.IndexOf(target);

            _items[index] = item;

            return await Task.FromResult(item.Id);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var target = _items.Where(h => h.Id == id).FirstOrDefault();
            _items.Remove(target);

            return await Task.FromResult(true);
        }

        public async Task<Habit> GetItemAsync(string id)
        {
            return await Task.FromResult(_items.FirstOrDefault(h => h.Id == id));
        }

        public async Task<IEnumerable<Habit>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_items);
        }

        public bool Save()
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                IgnoreNullValues = true,
                IgnoreReadOnlyProperties = true,
            };

            var json = JsonSerializer.Serialize(_items, options);
            File.WriteAllText(_filePath, json);

            return true;
        }

        public bool Clear()
        {
            _items.Clear();
            Save();

            return true;
        }
    }
}
