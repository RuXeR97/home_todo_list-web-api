using AutoMapper;
using Home_todo_list___entities.Entities;
using Home_todo_list___entities.OutputDtos;
using Home_todo_list___infrastructure.Abstraction.Repositories;
using Home_todo_list___infrastructure.Entities;
using Home_todo_list___infrastructure.Extensions;
using Home_todo_list___infrastructure.Other;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace Home_todo_list___infrastructure.Repositories
{
    public class ProjectRepository : ICRUDRepository<ProjectModel, ProjectsPagedDto, ProjectDto>
    {
        private readonly HomeTodoListDbContext _dbContext;
        private readonly IMapper _mapper;
        public ProjectRepository(HomeTodoListDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task AddAsync(ProjectModel addDto)
        {
            var projectToAdd = _mapper.Map<Project>(addDto);
            projectToAdd.CreationDate = DateTime.Now;
            await _dbContext.AddAsync(projectToAdd);

            var author = await _dbContext.Users.FirstAsync(i => i.Id == projectToAdd.CreatorId);
            var userAllowed = new UserProjectRight
            {
                UserId = author.Id,
                ProjectRightId = 2,
                ProjectId = projectToAdd.Id
            };
            projectToAdd.UsersAllowed.Add(userAllowed);
            
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProjectDto>> GetAllAsync(int userId)
        {
            var allUserProjects = await _dbContext.Projects.
                Where(i => i.UsersAllowed.Any(i => i.UserId == userId)).
                ToListAsync();
            var projectsDtos = _mapper.Map<IEnumerable<ProjectDto>>(allUserProjects);

            return projectsDtos;
        }

        public async Task<ProjectsPagedDto> GetPagedAsync(int userId, int page, int pageSize)
        {
            var allUserProjects = _dbContext.Projects.Where(i => i.UsersAllowed.Any(i => i.UserId == userId));
            var projectsCount = allUserProjects.Count();

            var projects = await allUserProjects.
                GetPaged(page, pageSize);
            var projectsDtos = _mapper.Map<IEnumerable<ProjectDto>>(projects.Results);

            return new ProjectsPagedDto
            {
                Projects = projectsDtos,
                ProjectsCount = projectsCount
            };
        }

        public async Task Remove(int id, int requestAuthorId)
        {
            try
            {
                var projectToRemove = new Project()
                {
                    Id = id,
                    UsersAllowed = new List<UserProjectRight>()
                    {
                        new UserProjectRight()
                        {
                            UserId = requestAuthorId
                        }
                    }
                };
                _dbContext.Projects.Remove(projectToRemove);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task RemoveRange(int[] ids, int requestAuthorId)
        {
            try
            {
                var projectsToRemove = _dbContext.Projects.
                    Where(i => 
                        i.UsersAllowed.FirstOrDefault(j => j.UserId == requestAuthorId).ProjectRightId == 2 &&
                        ids.Any(j => j == i.Id));
                _dbContext.RemoveRange(projectsToRemove);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
