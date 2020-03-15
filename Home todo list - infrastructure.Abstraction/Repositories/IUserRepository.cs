using Home_todo_list___entities;
using System.Collections.Generic;

namespace Home_todo_list___infrastructure.Abstraction.Repositories
{
    public interface IUserRepository
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
    }
}
