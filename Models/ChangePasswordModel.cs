using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class ChangePasswordModel
    {
        [Required, DataType(DataType.Password), Display(Name = "Поточний пароль")]
        public string CurrentPassword { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Новий пароль")]
        public string NewPassword { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Повторіть новий пароль")]
        [Compare("NewPassword", ErrorMessage = "Паролі не співпадають")]
        public string ConfirmPassword { get; set; }

    }
}
