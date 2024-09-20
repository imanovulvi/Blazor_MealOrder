using Meal.Shared.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal.Shared.DTOs
{
    public class OrderDTO:BaseEntityDTO
    {
        public int UserId { get; set; }

        public int SupplierId { get; set; }
        [Required,StringLength(10,ErrorMessage ="10 char cox ola bilmez")]
        public string Description { get; set; }
    }
}
