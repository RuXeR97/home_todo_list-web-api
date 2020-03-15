using Home_todo_list___entities;
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
        public User Authenticate(string username, string password)
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Username == username && x.PasswordHash.ToString() == password);
            return null;
            //        if (user == null)
            //            return null;
        }

        public IEnumerable<User> GetAll()
        {
            var asd = _dbContext.Users.ToList();
            var users = new List<User>();
            foreach(var item in asd)
            {
                users.Add(new User()
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
