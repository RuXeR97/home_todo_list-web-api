using AutoMapper;
using Home_todo_list___entities.Entities;
using Home_todo_list___entities.OutputDtos;
using Home_todo_list___infrastructure.Abstraction.Repositories;
using Home_todo_list___infrastructure.Entities;
using Home_todo_list___infrastructure.Other;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<UserAuthenticatedDto> Authenticate(AuthenticateUserModel authenticateUserModel)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Username == authenticateUserModel.Username);

            // check if password is correct
            if (!VerifyPasswordHash(authenticateUserModel.Password, user.PasswordHash, user.PasswordSalt))
                return null;

            return _mapper.Map<UserAuthenticatedDto>(user);
        }
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = _dbContext.Users.ToList();
            var usersDtos = _mapper.Map<IEnumerable<UserDto>>(users);

            return usersDtos;
        }
        public async Task<UserRegisteredDto> RegisterAccount(RegisterAccountModel registerAccountModel)
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

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            var registeredUserDto = _mapper.Map<UserRegisteredDto>(user);
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
