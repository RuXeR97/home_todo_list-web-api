using System;

namespace Home_todo_list___entities.Entities
{
    public class ProjectModel
    {
        public int CreatorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
    }
}
