using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal.Shared.DTOs
{
    public class UserLoginResponseDTO
    {
        public string Token { get; set; }
        public UserDTO User { get; set; }
    }
}
