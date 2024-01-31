using Microsoft.AspNetCore.Mvc;

namespace LiatrioPoC.Web.Controllers
{
    public class InsecureController : Controller
    {
        [Route("/insecure/xss")]
        public IActionResult Xss()
        {
            return View();
        }
    }
}
