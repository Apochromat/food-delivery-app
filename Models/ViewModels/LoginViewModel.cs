using System.ComponentModel.DataAnnotations;

namespace food_delivery_app.Models.ViewModels;

public class LoginViewModel {
    [Required(ErrorMessage = "Email обязателен для заполнения")]
    [DataType(DataType.EmailAddress)]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Пароль обязателен для заполнения")]
    [DataType(DataType.Password)]
    [Display(Name = "Пароль")]
    public string Password { get; set; }
}