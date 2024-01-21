using LiatrioPoC.Api.Models.Katas;
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

        [HttpGet("/katas")]
        public IActionResult List()
        {
            var katas = _kataRepository.GetAll();
            return Ok(katas);
        }

        [HttpPost("/katas")]
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
