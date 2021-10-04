using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DirecTvGo.Models
{
    // Models used as parameters to AccountController actions.
    public class ResponseTokenInfo
    {
        public string Id { get; set; }

        public DateTime Creation_Date { get; set; }

        public DateTime Update_date { get; set; }

        public DateTime Last_Login { get; set; }

        public string Token { get; set; }
        
    }

    public class reponseJWT 
    { 
        public string expires { get; set; }

        public string issued { get; set; }

        public string access_token { get; set; }

        public string expires_in { get; set; }

        public string token_type { get; set; }

        public string userName { get; set; }
    }
    
    public class AddExternalLoginBindingModel
    {
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }
    }

    public class ChangePasswordBindingModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterBindingModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }


        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "el {0} debe ser almenos {2} caracteres de largo.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "las contraseñas no conciden.")]
        public string ConfirmPassword { get; set; }

        
        public List<Phone> Phone { get; set; }
    }


    public class LoginSession
    {
        [Key]
        public string login_id { get; set; }
        
        public string userId { get; set; }

        public DateTime Creation_date { get; set; }

        public DateTime Update_date { get; set; }

        public DateTime Last_login { get; set; }

        [MaxLength]
        public string token { get; set; }

    }

    public class Phone 
    {
        [Key]
        public string id { get; set; }

        public string Extention { get; set; }

        
        public string PhoneNumber { get; set; }
    }

    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class RemoveLoginBindingModel
    {
        [Required]
        [Display(Name = "Login provider")]
        public string LoginProvider { get; set; }

        [Required]
        [Display(Name = "Provider key")]
        public string ProviderKey { get; set; }
    }

    public class SetPasswordBindingModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class UserLogin
    {
        public string UserEmail { get; set; }

        public string UserPassword { get; set; }
    }
}
