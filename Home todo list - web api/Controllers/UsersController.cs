using AutoMapper;
using Home_todo_list___core.Abstraction.BusinessLogic;
using Home_todo_list___entities.Entities;
using Home_todo_list___entities.InputDtos;
using Home_todo_list___entities.OutputDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Home_todo_list___web_api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserLogic _userLogic;
        private readonly IMapper _mapper;

        public UsersController(IUserLogic userLogic, IMapper mapper)
        {
            _userLogic = userLogic;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult<UserAuthenticatedDto>> Authenticate([FromBody]AuthenticateDto model)
        {
            //var claimsIdentity = this.User.Identity as ClaimsIdentity;
            //var userId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            var authenticateUserModel = _mapper.Map<AuthenticateUserModel>(model);
            var user = await _userLogic.Authenticate(authenticateUserModel);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("registeraccount")]
        public async Task<ActionResult<UserRegisteredDto>> RegisterAccount([FromBody]RegisterAccountDto model)
        {
            var registerAccountModel = _mapper.Map<RegisterAccountModel>(model);
            var user = await _userLogic.RegisterAccount(registerAccountModel);
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }


        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get()
        {
            return await _userLogic.GetAll();
        }
    }
}