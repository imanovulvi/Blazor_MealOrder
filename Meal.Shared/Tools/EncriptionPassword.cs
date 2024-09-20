using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal.Shared.Tools
{
    public class EncriptionPassword
    {
        public string Password(string password)
                =>  Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
    }
}
