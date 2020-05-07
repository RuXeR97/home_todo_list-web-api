using System.Collections.Generic;

namespace Home_todo_list___entities.OutputDtos
{
    public class ProjectsPagedDto
    {
        public int ProjectsCount { get; set; }
        public IEnumerable<ProjectDto> Projects { get; set; }
    }
}
