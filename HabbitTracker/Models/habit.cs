using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabbitTracker.Models
{
    internal class habit
    {
        public int habitId { get; set; }
        public string habitName { get; set; }
        public string quantityName { get; set; }
        public int defaultQuantity { get; set; }
    }
}
