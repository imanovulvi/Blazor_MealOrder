using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meal.Shared.ResponseModel
{
    public abstract class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
        }
        public string Message { get; set; }
        public bool Success { get; set; }

        public void SetException(Exception exception)
        {
            Success = false;
            Message=exception.Message;


        }
    }
}
