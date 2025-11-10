using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabbitTracker.Models
{
    internal class Occurences
    {
        public int occurenceId { get; set; }
        public int habitId { get; set; }
        public int habitQuantity { get; set; }
        public DateTime Date { get; set; }
    }
}
