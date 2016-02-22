namespace BulBike.Web.Models.AccountViewModels
{
    using BulBike.Web.Infrastructure.Mapping;
    using BulBike.Models;

    public class UserResponseModel : IMapFrom<User>
    {
        public string Username { get; set; }

        public string Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}