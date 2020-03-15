using System.ComponentModel.DataAnnotations;

namespace Home_todo_list___entities.InputDtos
{
    public class AuthenticateDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
