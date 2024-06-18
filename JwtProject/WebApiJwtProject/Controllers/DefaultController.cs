using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiJwtProject.Models;

namespace WebApiJwtProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult GenerateToken()
        {
            return Ok(new CreateToken().Create());
        }

        [HttpGet("[action]")]
        public IActionResult GenerateTokenForAdmin()
        {
            return Ok(new CreateToken().CreateForAdmin());
        }
        [Authorize]
        [HttpGet("[action]")]
        public IActionResult Test()
        {
            return Ok("Hoşgelidinz");
        }

        [Authorize(Roles ="Admin,Visitor")]
        [HttpGet("[action]")]
        public IActionResult Test3()
        {
            return Ok("token burada");
        }
    }
}
