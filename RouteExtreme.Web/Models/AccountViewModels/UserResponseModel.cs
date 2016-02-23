namespace RouteExtreme.Web.Models.AccountViewModels
{
    using RouteExtreme.Web.Infrastructure.Mapping;
    using RouteExtreme.Models;

    public class UserResponseModel : IMapFrom<User>
    {
        public string Username { get; set; }

        public string Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}