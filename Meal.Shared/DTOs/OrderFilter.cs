using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal.Shared.DTOs
{
    public class OrderFilter
    {
        public int UserId { get; set; }
        public DateTime CreateDateMin { get; set; }
        public DateTime CreateDateMax { get; set; }
    }
}
