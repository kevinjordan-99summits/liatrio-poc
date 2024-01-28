using LiatrioPoC.Core.Entities;
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

        /// <summary>
        /// List all categories
        /// </summary>
        /// <response code="200">Returns a list of all categories</response>
        [HttpGet("/categories")]
        [ProducesResponseType(typeof(IEnumerable<Category>), 200)]
        [Produces("application/json")]
        public IActionResult List()
        {
            var categories = _categoryRepository.GetAll();
            return Ok(categories);
        }
    }
}
