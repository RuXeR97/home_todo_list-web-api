using Home_todo_list___common;
using Home_todo_list___core.Abstraction.BusinessLogic;
using Home_todo_list___entities.Entities;
using Home_todo_list___entities.OutputDtos;
using Home_todo_list___infrastructure.Abstraction.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Home_todo_list___core.BusinessLogic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _userRepository;
        public UserLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserAuthenticatedDto> Authenticate(AuthenticateUserModel authenticateUserModel)
        {
            var userFound = await _userRepository.Authenticate(authenticateUserModel);

            if (userFound == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(GlobalSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                            new Claim(ClaimTypes.Name, userFound.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            userFound.Token = tokenHandler.WriteToken(token);

            return userFound;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<UserRegisteredDto> RegisterAccount(RegisterAccountModel model)
        {
            return await _userRepository.RegisterAccount(model);
        }
    }
}
