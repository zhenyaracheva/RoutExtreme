using RouteExtreme.Models;
using RouteExtreme.Web.Infrastructure.Mapping;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RouteExtreme.Web.Areas.Admin.Models
{

    public class UserViewModel : IMapFrom<User>
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }
        
        [Display(Name = "Username")]
        public string UserName { get; set; }
        
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        
        [Display(Name = "Email")]
        public string Email { get; set; }        
    }
}