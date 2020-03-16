using Home_todo_list___entities.Entities;
using Home_todo_list___entities.OutputDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Home_todo_list___core.Abstraction.BusinessLogic
{
    public interface IUserLogic
    {
        Task<UserAuthenticatedDto> Authenticate(AuthenticateUserModel authenticateUserModel);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserRegisteredDto> RegisterAccount(RegisterAccountModel model);
    }
}
