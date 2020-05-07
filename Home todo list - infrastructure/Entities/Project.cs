using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home_todo_list___infrastructure.Entities
{
    public class Project
    {
        public Project()
        {
            ProjectAuthors = new HashSet<ProjectAuthor>();
            UsersAllowed = new HashSet<UserProjectRight>();
            Tasks = new HashSet<Task>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public virtual int CreatorId { get; set; }
        public virtual ICollection<ProjectAuthor> ProjectAuthors { get; set; }
        public virtual ICollection<UserProjectRight> UsersAllowed { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
