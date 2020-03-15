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

namespace Home_todo_list___core.BusinessLogic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _userRepository;
        public UserLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public UserAuthenticatedDto Authenticate(AuthenticateUserModel authenticateUserModel)
        {
            var userFound = _userRepository.Authenticate(authenticateUserModel);

            if (userFound == null)
                return null;

            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //                new Claim(ClaimTypes.Name, userFound.Id.ToString())
            //    }),
            //    Expires = DateTime.UtcNow.AddMinutes(30),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //userFound.Token = tokenHandler.WriteToken(token);

            // return userFound.WithoutPassword();
            return userFound;
        }

        public IEnumerable<UserDto> GetAll()
        {
            return _userRepository.GetAll();
        }

        public UserRegisteredDto RegisterAccount(RegisterAccountModel model)
        {
            throw new NotImplementedException();
        }
    }
}
