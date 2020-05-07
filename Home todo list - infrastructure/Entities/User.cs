using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Home_todo_list___infrastructure.Entities
{
    public class User
    {
        public User()
        {
            ProjectsAssigned = new HashSet<Project>();
            ProjectsOwned = new HashSet<ProjectAuthor>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public virtual ICollection<Project> ProjectsAssigned  { get; set; }
        public virtual ICollection<ProjectAuthor> ProjectsOwned { get; set; }
    }
}
