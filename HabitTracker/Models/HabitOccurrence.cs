

namespace HabitTracker.Models
{
    internal class HabitOccurrence
    {
        public int habitId { get; set; }
        public string? habitName { get; set; }
        public int occurrenceId { get; set; }
        public int habitQuantity { get; set; }
        public DateTime date { get; set; }
        public string? quantityName { get; set; }
    }
}
