using Home_todo_list___core.Abstraction.BusinessLogic;
using Home_todo_list___entities.Entities;
using Home_todo_list___entities.OutputDtos;
using Home_todo_list___infrastructure.Abstraction.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Home_todo_list___core.BusinessLogic
{
    public class ProjectLogic : ICRUDLogic<ProjectModel, ProjectsPagedDto, ProjectDto>
    {
        private readonly ICRUDRepository<ProjectModel, ProjectsPagedDto, ProjectDto> _crudRepository;
        public ProjectLogic(ICRUDRepository<ProjectModel, ProjectsPagedDto, ProjectDto> crudRepository)
        {
            _crudRepository = crudRepository;
        }
        public async Task AddAsync(ProjectModel addDto)
        {
            await _crudRepository.AddAsync(addDto);
        }

        public async Task<IEnumerable<ProjectDto>> GetAll(int userId)
        {
            return await _crudRepository.GetAllAsync(userId);
        }

        public async Task<ProjectsPagedDto> GetPaged(int userId, int page, int pageSize)
        {
            return await _crudRepository.GetPagedAsync(userId, page, pageSize);
        }

        public async Task RemoveAsync(int id, int requestAuthorId)
        {
            await _crudRepository.Remove(id, requestAuthorId);
        }

        public async Task RemoveRangeAsync(int[] ids, int requestAuthorId)
        {
            await _crudRepository.RemoveRange(ids, requestAuthorId);
        }
    }
}
