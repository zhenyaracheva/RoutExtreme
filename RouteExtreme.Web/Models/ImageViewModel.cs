namespace RouteExtreme.Web.Models
{
    using RouteExtreme.Models;
    using RouteExtreme.Web.Infrastructure.Mapping;

    public class ImageViewModel : IMapFrom<Image>
    {
        public int Id { get; set; }

        public byte[] Content { get; set; }

        public string FileExtension { get; set; }
    }
}