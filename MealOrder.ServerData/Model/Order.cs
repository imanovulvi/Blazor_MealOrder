using MealOrder.ServerData.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealOrder.ServerData.Model
{
    public class Order:BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public string Description { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
