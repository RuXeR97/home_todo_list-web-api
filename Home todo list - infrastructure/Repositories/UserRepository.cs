using Home_todo_list___entities;
using Home_todo_list___entities.Entities;
using Home_todo_list___entities.OutputDtos;
using Home_todo_list___infrastructure.Abstraction.Repositories;
using Home_todo_list___infrastructure.Other;
using System.Collections.Generic;
using System.Linq;

namespace Home_todo_list___infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HomeTodoListDbContext _dbContext;
        public UserRepository(HomeTodoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public UserAuthenticatedDto Authenticate(AuthenticateUserModel authenticateUserModel)
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Username == authenticateUserModel.Username && x.PasswordHash.ToString() == authenticateUserModel.Password);
            return null;
            //        if (user == null)
            //            return null;
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
    }
}
