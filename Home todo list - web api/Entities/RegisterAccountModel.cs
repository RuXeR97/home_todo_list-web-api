using System.ComponentModel.DataAnnotations;

namespace Home_todo_list___web_api.Entities
{
    public class RegisterAccountModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
