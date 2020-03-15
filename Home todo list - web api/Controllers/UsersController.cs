using AutoMapper;
using Home_todo_list___core.Abstraction.BusinessLogic;
using Home_todo_list___entities.Entities;
using Home_todo_list___entities.InputDtos;
using Home_todo_list___entities.OutputDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Home_todo_list___web_api.Controllers
{
    //[Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserLogic _userLogic;
        private readonly ILogger<UsersController> _logger;
        private readonly IMapper _mapper;

        public UsersController(IUserLogic userLogic, ILogger<UsersController> logger, IMapper mapper)
        {
            _userLogic = userLogic;
            _logger = logger;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ActionResult<UserAuthenticatedDto> Authenticate([FromBody]AuthenticateDto model)
        {
            var authenticateUserModel = _mapper.Map<AuthenticateUserModel>(model);
            var user = _userLogic.Authenticate(authenticateUserModel);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("registeraccount")]
        public ActionResult<UserRegisteredDto> RegisterAccount([FromBody]RegisterAccountDto model)
        {
            var registerAccountModel = _mapper.Map<RegisterAccountModel>(model);
            var user = _userLogic.RegisterAccount(registerAccountModel);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }


        [HttpGet]
        public IEnumerable<UserDto> Get()
        {
            //_logger.LogInformation("Log message in the About() method");
            return _userLogic.GetAll();
        }
    }
}