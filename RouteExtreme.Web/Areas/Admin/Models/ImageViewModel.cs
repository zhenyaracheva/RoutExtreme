namespace RouteExtreme.Web.Areas.Admin.Models
{
    using RouteExtreme.Models;
    using RouteExtreme.Web.Infrastructure.Mapping;

    public class ImageViewModel : IMapFrom<Image>
    {
        public int Id { get; set; }
    }
}