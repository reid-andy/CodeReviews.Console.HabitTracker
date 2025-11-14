
namespace HabbitTracker.Models
{
    internal class Occurrence
    {
        public int occurrenceId { get; set; }
        public int habitId { get; set; }
        public int habitQuantity { get; set; }
        public DateTime date { get; set; }

        public Occurrence(int habitId, int habitQuantity, DateTime date)
        {
            this.habitId = habitId;
            this.habitQuantity = habitQuantity;
            this.date = date;
        }
    }
}
