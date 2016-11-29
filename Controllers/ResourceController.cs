using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthDemo.Controllers
{
    [Authorize(ActiveAuthenticationSchemes = "Bearer")]
    public class ResourceController : Controller
    {
        [HttpGet]
        [Route("resource")]
        public IActionResult Get()
        {
            return Ok("This is a resource");
        }
    }
}
