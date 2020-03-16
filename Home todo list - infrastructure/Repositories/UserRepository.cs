using AutoMapper;
using Home_todo_list___entities.Entities;
using Home_todo_list___entities.OutputDtos;
using Home_todo_list___infrastructure.Abstraction.Repositories;
using Home_todo_list___infrastructure.Entities;
using Home_todo_list___infrastructure.Other;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Home_todo_list___infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HomeTodoListDbContext _dbContext;
        private readonly IMapper _mapper;
        public UserRepository(HomeTodoListDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public UserAuthenticatedDto Authenticate(AuthenticateUserModel authenticateUserModel)
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Username == authenticateUserModel.Username && x.PasswordHash.ToString() == authenticateUserModel.Password);

            // check if password is correct
            if (!VerifyPasswordHash(authenticateUserModel.Password, user.PasswordHash, user.PasswordSalt))
                return null;

            return _mapper.Map<UserAuthenticatedDto>(user);
        }

        public IEnumerable<UserDto> GetAll()
        {
            var asd = _dbContext.Users.ToList();
            var users = new List<UserDto>();
            foreach(var item in asd)
            {
                users.Add(new UserDto()
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Username = item.Username
                });
            }

            return users;
        }

        public UserRegisteredDto RegisterAccount(RegisterAccountModel registerAccountModel)
        {
            if (string.IsNullOrWhiteSpace(registerAccountModel.Password))
                throw new Exception("Password is required");

            if (_dbContext.Users.Any(x => x.Username == registerAccountModel.Username))
                throw new Exception("Username \"" + registerAccountModel.Username + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(registerAccountModel.Password, out passwordHash, out passwordSalt);

            var user = _mapper.Map<User>(registerAccountModel);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            var registeredUser = _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            var registeredUserDto = _mapper.Map<UserRegisteredDto>(registeredUser);
            return registeredUserDto;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
