using Home_todo_list___entities.Entities;
using Home_todo_list___entities.OutputDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Home_todo_list___infrastructure.Abstraction.Repositories
{
    public interface IUserRepository
    {
        Task<UserAuthenticatedDto> Authenticate(AuthenticateUserModel authenticateUserModel);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserRegisteredDto> RegisterAccount(RegisterAccountModel registerAccountModel);
    }
}
