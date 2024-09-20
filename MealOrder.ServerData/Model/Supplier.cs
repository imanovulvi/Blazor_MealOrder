using MealOrder.ServerData.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealOrder.ServerData.Model
{
    public class Supplier:BaseEntity
    {
        public string Name { get; set; }
        public string WebUri { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
