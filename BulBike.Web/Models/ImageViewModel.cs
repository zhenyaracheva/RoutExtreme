namespace BulBike.Web.Models
{
    using BulBike.Models;
    using BulBike.Web.Infrastructure.Mapping;

    public class ImageViewModel : IMapFrom<Image>
    {
        public byte[] Content { get; set; }

        public string FileExtension { get; set; }
    }
}