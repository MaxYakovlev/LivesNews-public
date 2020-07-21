using System.ComponentModel.DataAnnotations;

namespace uNews.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введите email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [MinLength(10, ErrorMessage = "Пароль должен содержать минимум 10 символов")]
        [MaxLength(20, ErrorMessage = "Пароль может содержать максимум 20 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Повторите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string RepeatPassword { get; set; }
    }
}
