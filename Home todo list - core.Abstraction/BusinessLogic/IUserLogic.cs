using Home_todo_list___entities.Entities;
using Home_todo_list___entities.OutputDtos;
using System.Collections.Generic;

namespace Home_todo_list___core.Abstraction.BusinessLogic
{
    public interface IUserLogic
    {
        UserAuthenticatedDto Authenticate(AuthenticateUserModel authenticateUserModel);
        IEnumerable<UserDto> GetAll();
        UserRegisteredDto RegisterAccount(RegisterAccountModel model);
    }
}
