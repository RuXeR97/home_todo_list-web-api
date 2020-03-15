using System.ComponentModel.DataAnnotations;

namespace Home_todo_list___entities.Entities
{
    public class AuthenticateUserModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
