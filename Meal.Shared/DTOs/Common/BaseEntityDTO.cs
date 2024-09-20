using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal.Shared.DTOs.Common
{
    public abstract class BaseEntityDTO
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsAktiv { get; set; }
    }
}
