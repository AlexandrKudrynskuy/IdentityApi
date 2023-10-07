using System.ComponentModel.DataAnnotations;

namespace Store_Identity_API.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        
    }
}
