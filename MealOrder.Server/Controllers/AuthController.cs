using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace MealOrder.Server.Controllers
{

    public class AuthController : ControllerBase
    {
        public AuthController()
        {
            
        }
        [NonAction]
         public async Task Tst(string roll)
        {


            var a = Request.Headers["auth"];



            if (roll!=a)
            {
                Response.StatusCode = 401;
               await  Response.WriteAsync(
                    """
                    {
                        "name":"null",
                        "surname":"null"
                    }

                    """
                    
                    
                    );
            }
           
        }
    }
}
