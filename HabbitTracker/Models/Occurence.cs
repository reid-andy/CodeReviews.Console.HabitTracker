
namespace HabbitTracker.Models
{
    internal class Occurence
    {
        public int occurenceId { get; set; }
        public int habitId { get; set; }
        public int habitQuantity { get; set; }
        public DateTime Date { get; set; }
    }
}
