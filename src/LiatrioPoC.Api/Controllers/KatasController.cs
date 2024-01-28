using LiatrioPoC.Api.Models.Katas;
using LiatrioPoC.Core.Entities;
using LiatrioPoC.Core.Repositories;
using LiatrioPoC.Core.Services.Katas;
using Microsoft.AspNetCore.Mvc;

namespace LiatrioPoC.Api.Controllers
{
    [ApiController]
    public class KatasController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IKataRepository _kataRepository;
        private readonly ILogger<KatasController> _logger;

        public KatasController(
            ICategoryRepository categoryRepository,
            IKataRepository kataRepository,
            ILogger<KatasController> logger)
        {
            _categoryRepository = categoryRepository;
            _kataRepository = kataRepository;
            _logger = logger;
        }

        /// <summary>
        /// Get all katas
        /// </summary>
        /// <response code="200">Returns a list of all katas</response>
        [HttpGet("/katas")]
        [ProducesResponseType(typeof(IEnumerable<Kata>), 200)]
        [Produces("application/json")]
        public IActionResult List()
        {
            var katas = new ListKatasQuery(_kataRepository).List();
            return Ok(katas);
        }

        /// <summary>
        /// Get all katas underneath a category
        /// </summary>
        /// <param name="categoryId">The unique identifier for the category the katas are under</param>
        /// <response code="200">Returns a list of katas under a category</response>
        [HttpGet("/categories/{categoryId:guid}/katas")]
        [ProducesResponseType(typeof(IEnumerable<Kata>), 200)]
        [Produces("application/json")]
        public IActionResult GetByCategory([FromRoute] Guid categoryId)
        {
            var katas = new GetKatasByCategoryQuery(_kataRepository).Get(categoryId);
            return Ok(katas);
        }

        /// <summary>
        /// Create a new kata
        /// </summary>
        /// <response code="200">The kata that was created</response>
        /// <response code="400">Bad parameters</response>
        [HttpPost("/katas")]
        [ProducesResponseType(typeof(Kata), 200)]
        [Produces("application/json")]
        public IActionResult Post([FromBody]KatasPostModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var kata = new CreateKataCommand(_categoryRepository, _kataRepository)
                .Create(model.CategoryId, model.Name, model.Description);

            if (kata is null)
                return BadRequest();

            return Ok(kata);
        }
    }
}
