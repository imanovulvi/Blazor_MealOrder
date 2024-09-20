using Meal.Shared.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal.Shared.DTOs
{
    public class SupplierDTO : BaseEntityDTO
    {
        public string Name { get; set; }
        public string WebUri { get; set; }
    }
}
