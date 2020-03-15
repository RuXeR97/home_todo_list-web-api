using Home_todo_list___entities;
using Home_todo_list___entities.Entities;
using Home_todo_list___entities.OutputDtos;
using System.Collections.Generic;

namespace Home_todo_list___infrastructure.Abstraction.Repositories
{
    public interface IUserRepository
    {
        UserAuthenticatedDto Authenticate(AuthenticateUserModel authenticateUserModel);
        IEnumerable<UserDto> GetAll();

    }
}
