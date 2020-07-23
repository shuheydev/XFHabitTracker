using System;
using System.Collections.Generic;
using System.Text;

namespace XFHabitTracker.Models
{
    public class Habit
    {
        public string Name { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        public DateTimeOffset CreatedAt { get; set; }
    }

    public class Record
    {
        public string Id { get; set; } = string.Empty;
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
    }
}
