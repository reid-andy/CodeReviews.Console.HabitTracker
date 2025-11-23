
namespace HabitTracker.Models
{
    internal class Occurrence
    {
        public int occurrenceId { get; set; }
        public int habitId { get; set; }
        public int habitQuantity { get; set; }
        public string date { get; set; }

        public Occurrence(int habitId, int habitQuantity, string date)
        {
            this.habitId = habitId;
            this.habitQuantity = habitQuantity;
            this.date = date;
        }
    }
}
