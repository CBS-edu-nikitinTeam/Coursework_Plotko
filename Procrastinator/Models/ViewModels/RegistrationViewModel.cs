using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Procrastinator.Models.ViewModels
{
    public class RegistrationViewModel
    {
        [Display(Name = "Your first name")]
        public string FirstName { get; set; }

        [Display(Name = "Your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Fill in your email")]
        [Display(Name = "Email")]
        [UIHint("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Fill in your password")]
        [Display(Name = "Password")]
        [UIHint("Password")]
        public string Password { get; set; }

        [Display(Name = "Confirm your password")]
        [UIHint("Password")]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }
    }
}
