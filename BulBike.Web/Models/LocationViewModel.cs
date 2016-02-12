namespace BulBike.Web.Models
{
    using BulBike.Models;
    using Infrastructure.Mapping;

    public class LocationViewModel : IMapFrom<Location>
    {
        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }
}