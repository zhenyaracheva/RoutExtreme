﻿namespace BulBike.Web.Models.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public HttpPostedFileBase ProfilePic { get; set; }
    }
}