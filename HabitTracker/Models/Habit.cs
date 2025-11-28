
namespace HabitTracker.Models
{
    internal class Habit
    {
        public int habitId { get; set; }
        public string? habitName { get; set; }
        public string? quantityName { get; set; }

        public Habit(string? habitName, string? quantityName, int? habitId = null)
        {
            this.habitName = habitName;
            this.quantityName = quantityName;
            if (habitId != null) this.habitId = (int)habitId;

        }
    }
}
