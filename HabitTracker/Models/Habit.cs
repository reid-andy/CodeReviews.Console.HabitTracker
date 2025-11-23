
namespace HabitTracker.Models
{
    internal class Habit
    {
        public int habitId { get; set; }
        public string? habitName { get; set; }
        public string? quantityName { get; set; }
        public int defaultQuantity { get; set; }
    }

}
