using System.Collections.Generic;
using System.Threading.Tasks;

namespace Home_todo_list___infrastructure.Abstraction.Repositories
{
    public interface ICRUDRepository<TModel, TPagedDto, TDto>
    {
        Task AddAsync(TModel addDto);
        Task Remove(int id, int requestAuthorId);
        Task RemoveRange(int[] ids, int requestAuthorId);
        Task<TPagedDto> GetPagedAsync(int userId, int page, int pageSize);
        Task<IEnumerable<TDto>> GetAllAsync(int userId);
    }
}
