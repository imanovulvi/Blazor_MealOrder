using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MealOrder.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : AuthController
    {


        [HttpGet]
        public async Task<IActionResult> Get()
        {
          await Tst("admin");
            return Ok(new {name="ulvi",surname="imanov" });
        }

        [HttpGet]
        public async Task<IActionResult> Get2()
        {
            await Tst("user");
            return Ok(new { name = "ulvi2", surname = "imanov2" });
        }
    }
}
