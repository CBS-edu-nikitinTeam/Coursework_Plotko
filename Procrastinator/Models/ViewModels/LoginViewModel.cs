using System.ComponentModel.DataAnnotations;

namespace Procrastinator.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Fill in your name")]
        [Display(Name = "Login")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Fill in your password")]
        [UIHint("Password")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
