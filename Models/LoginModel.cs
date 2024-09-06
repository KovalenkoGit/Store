using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class LoginModel
    {
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Запам'ятати")]
        public bool RememberMe { get; set; } = false;
    }
}
