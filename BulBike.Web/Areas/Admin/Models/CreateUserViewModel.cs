namespace BulBike.Web.Areas.Admin.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public class CreateUserViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} characters long.", MinimumLength = 5)]
        [Index(IsUnique = true)]
        [Display(Name = "Username")]
        [UIHint("SingleLineText")]
        public string Username { get; set; }

        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} characters long.", MinimumLength = 2)]
        [Display(Name = "First name")]
        [UIHint("SingleLineText")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Last name")]
        [UIHint("SingleLineText")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [UIHint("SingleLineText")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [UIHint("Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [UIHint("Password")]
        public string ConfirmPassword { get; set; }
    }
}