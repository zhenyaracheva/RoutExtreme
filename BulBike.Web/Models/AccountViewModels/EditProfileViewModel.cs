namespace BulBike.Web.Models.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class EditProfileViewModel
    {
        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} characters long.", MinimumLength = 2)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public HttpPostedFileBase ProfilePic { get; set; }
    }
}