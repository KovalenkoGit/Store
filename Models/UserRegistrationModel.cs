using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class UserRegistrationModel
    {
        [Display(Name = "Введіть ім'я")]
        public string FirstName { get; set; }
        [Display(Name = "Введіть прізвище")]
        public string LastName { get; set; }
        [NotMapped]
        [Display(Name = "Email адреса")]
        [Required(ErrorMessage = "Введіть Email")]
        [EmailAddress(ErrorMessage = "Невірно вказано Email")]
        public string Email { get; set; }
        [NotMapped]
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Введіть пароль")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage = "Паролі не збігаються")]
        public string Password { get; set; }
        [NotMapped]
        [Display(Name = "Повторіть пароль")]
        [Required(ErrorMessage = "Повторіть пароль")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
