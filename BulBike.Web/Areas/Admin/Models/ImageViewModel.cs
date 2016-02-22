namespace BulBike.Web.Areas.Admin.Models
{
    using BulBike.Models;
    using BulBike.Web.Infrastructure.Mapping;

    public class ImageViewModel : IMapFrom<Image>
    {
        public int Id { get; set; }
    }
}