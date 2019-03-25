using System.ComponentModel.DataAnnotations;

namespace eDrinkShop.Web.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "EMAIL")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name ="Remember me?")]
        public bool RememberMe { get; set; }
    }
}
