namespace RouteExtreme.Web.Models.AccountViewModels
{
    using AutoMapper;
    using RouteExtreme.Models;
    using RouteExtreme.Web.Infrastructure.Mapping;

    public class UserDetailsViewModel : IMapFrom<User>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public int? ProfilePicId { get; set; }

        public bool IsDeleted { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
        }
    }
}