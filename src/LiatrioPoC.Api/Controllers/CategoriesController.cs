using LiatrioPoC.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LiatrioPoC.Api.Controllers
{
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(
            ICategoryRepository categoryRepository,
            ILogger<CategoriesController> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        [HttpGet("/categories")]
        public IActionResult List()
        {
            var categories = _categoryRepository.GetAll();
            return Ok(categories);
        }
    }
}
