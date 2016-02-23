namespace RouteExtreme.Web.Models
{
    using System;
    using AutoMapper;
    using RouteExtreme.Models;
    using Infrastructure.Mapping;

    public class LocationViewModel : IMapFrom<Location>, IHaveCustomMappings
    {
        public double lat { get; set; }

        public double lng { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Location, LocationViewModel>("LocationDisplay")
                 .ForMember(m => m.lat, opt => opt.MapFrom(t => t.Latitude))
                 .ForMember(m => m.lng, opt => opt.MapFrom(t => t.Longitude))
                 .ReverseMap();
        }
    }
}