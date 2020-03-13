using Home_todo_list___web_api.Entities;
using Home_todo_list___web_api.Models;
using Home_todo_list___web_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Home_todo_list___web_api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        
        [HttpGet]
        public IEnumerable<User> Get()
        {
            //_logger.LogInformation("Log message in the About() method");
            return new List<User>()
            {
                new User
                {
                    FirstName = "a",
                    LastName = "b"
                }
            };
        }
    }
}