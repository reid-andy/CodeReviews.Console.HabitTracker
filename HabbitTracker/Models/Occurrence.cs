
namespace HabbitTracker.Models
{
    internal class Occurrence
    {
        public int occurrenceId { get; set; }
        public int habitId { get; set; }
        public int habitQuantity { get; set; }
        public DateTime Date { get; set; }
    }
}
