

namespace HabbitTracker.Models
{
    internal class HabitOccurence
    {
        public int habitId { get; set; }
        public string? habitName { get; set; }
        public int occurenceId { get; set; }
        public int habitQuantity { get; set; }
        public DateTime date { get; set; }
        public string? quantityName { get; set; }
    }
}
