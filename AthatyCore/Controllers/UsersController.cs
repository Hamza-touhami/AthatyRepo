using AthatyCore.Entities;
using AthatyCore.Services;
using AthatyCore.Helpers;
using Microsoft.AspNetCore.Mvc;


namespace AthatyCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticationRequest request)
        {
            var response = userService.Authenticate(request);

            if (response == null)
                return BadRequest(new { message = "Username or password incorrect" });

            return Ok(response);
        }

        
        [HttpGet]
        [Authorize]
        public IActionResult GetUsers()
        {
            return Ok(userService.GetUsers());
        }

    }
}
