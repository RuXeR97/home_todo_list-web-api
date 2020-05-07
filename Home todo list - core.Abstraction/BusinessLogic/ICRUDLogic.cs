using System.Collections.Generic;
using System.Threading.Tasks;

namespace Home_todo_list___core.Abstraction.BusinessLogic
{
    public interface ICRUDLogic<TModel, TPagedDto, TDto>
    {
        Task AddAsync(TModel addDto);
        Task RemoveAsync(int id, int requestAuthorId);
        Task RemoveRangeAsync(int[] ids, int requestAuthorId);
        Task<TPagedDto> GetPaged(int userId, int page, int pageSize);
        Task<IEnumerable<TDto>> GetAll(int userId);
    }
}
