using Microsoft.AspNetCore.Mvc;

namespace LiatrioPoC.Api.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Get()
        {
            return Ok("I am NOT a teapot.");
        }
    }
}
