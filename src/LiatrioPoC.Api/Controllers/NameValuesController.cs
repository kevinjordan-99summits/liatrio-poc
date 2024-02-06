using LiatrioPoC.Api.Models.NameValues;
using Microsoft.AspNetCore.Mvc;

namespace LiatrioPoC.Api.Controllers
{
    [ApiController]
    public class NameValuesController : ControllerBase
    {
        /// <summary>
        /// Get a set of name value pairs for testing random things
        /// </summary>
        [HttpGet("/name-values")]
        [ProducesResponseType(typeof(IEnumerable<NameValueGetModel>), 200)]
        [Produces("application/json")]
        public IActionResult List()
        {
            return Ok(new List<NameValueGetModel>
            {
                new NameValueGetModel{ Id = Guid.NewGuid(), Name = "App Name", Value = "My Site" },
                new NameValueGetModel{ Id = Guid.NewGuid(), Name = "Environment", Value = "DEV" },
                new NameValueGetModel{ Id = Guid.NewGuid(), Name = "SecretPassword", Value = "DontLookAtMe!", IsSecret = true },
                new NameValueGetModel{ Id = Guid.NewGuid(), Name = "BaseUrl", Value = "https://dev.mysite.com" }
            });
        }
    }
}
