namespace BulBike.Web.Areas.Admin.Models
{
    using BulBike.Models;
    using BulBike.Web.Infrastructure.Mapping;

    public class ResponseUserViewModel : IMapFrom<User>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }
    }
}