using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal.Shared.ResponseModel
{
    public class ServiceResponse<T>:BaseResponse where T : class
    {
      
        public T Value { get; set; }
    }
}
