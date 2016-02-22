namespace BulBike.Web.Areas.Admin.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    public class EditUserViewModel
    {
       
        public string Id { get; set; }
        
        [Display(Name = "Username")]
        public string UserName { get; set; }
        
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}