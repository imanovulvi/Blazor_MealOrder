using Meal.Shared.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal.Shared.DTOs
{
    public class OrderItemDTO : BaseEntityDTO
    {
        public int OrderId { get; set; }

        public int UserId { get; set; }
        public string Description { get; set; }
    }
}
