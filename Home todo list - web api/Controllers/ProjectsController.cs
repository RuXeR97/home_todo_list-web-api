using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Home_todo_list___core.Abstraction.BusinessLogic;
using Home_todo_list___entities.Entities;
using Home_todo_list___entities.OutputDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;

namespace Home_todo_list___web_api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ICRUDLogic<ProjectModel, ProjectsPagedDto, ProjectDto> _crudLogic;
        private readonly IMapper _mapper;

        public ProjectsController(ICRUDLogic<ProjectModel, ProjectsPagedDto, ProjectDto> crudLogic, IMapper mapper)
        {
            _crudLogic = crudLogic;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjects()
        {
            int requestAuthorId = GetRequestAuthorId();
            var projectsDtos = await _crudLogic.GetAll(requestAuthorId);
            return Ok(projectsDtos);
        }

        [HttpGet("getprojectspaged")]
        public async Task<ActionResult<ProjectsPagedDto>> GetProjectsPaged(int page, int pageSize)
        {
            int requestAuthorId = GetRequestAuthorId();
            var projectsDtos = await _crudLogic.GetPaged(requestAuthorId, page, pageSize);
            return  Ok(projectsDtos);
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddProject([FromBody]ProjectModel projectModel)
        {
            projectModel.CreatorId = GetRequestAuthorId();
            await _crudLogic.AddAsync(projectModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveProject(int id)
        {
            int requestAuthorId = GetRequestAuthorId();
            await _crudLogic.RemoveAsync(id, requestAuthorId);
            return Ok();
        }

        [HttpDelete("removeprojects")]
        public async Task<ActionResult> RemoveProjects(int[] ids)
        {
            int requestAuthorId = GetRequestAuthorId();
            await _crudLogic.RemoveRangeAsync(ids, requestAuthorId);
            return Ok();
        }

        private int GetRequestAuthorId()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userIdString = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
            bool isUserIdValid = int.TryParse(userIdString, out int creatorId);
            if (!isUserIdValid)
            {
                throw new Exception("Something went wrong");
            }

            return creatorId;
        }
    }
}
