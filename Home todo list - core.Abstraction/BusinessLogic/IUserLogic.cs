using Dtos;
using Home_todo_list___entities;
using System.Collections.Generic;

namespace Home_todo_list___core.Abstraction.BusinessLogic
{
    public interface IUserLogic
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        RegisterAccountDto RegisterAccount(RegisterAccountModel model);
    }
}
