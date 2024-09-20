using MealOrder.ServerData.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealOrder.ServerData.Model
{
    public class OrderItem:BaseEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }    
        public int UserId { get; set; }
        public string Description { get; set; }
    }
}
