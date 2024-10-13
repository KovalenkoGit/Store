using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class ForgotPasswordModel
    {
        [Required, EmailAddress, Display(Name = "Ваш Email використаний під час реєстрації")]
        public string Email { get; set; }
        public bool EmailSent { get; set; }
    }
}
