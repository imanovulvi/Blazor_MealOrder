using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal.Shared.DTOs
{
    public class UserLoginRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
