using LiatrioPoC.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LiatrioPoC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppConfiguration _configuration;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IAppConfiguration configuration)
        {
            _logger = logger;
            this._configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/categories/{categoryId:guid}")]
        public IActionResult Katas(Guid categoryId)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
