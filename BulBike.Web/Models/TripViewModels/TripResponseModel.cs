namespace BulBike.Web.Models.TripViewModels
{
    using BulBike.Models;
    using BulBike.Web.Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using BulBike.Web.Models.AccountViewModels;

    public class TripResponseModel : IMapFrom<Trip>, IHaveCustomMappings
    {

        public DateTime StartDate { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Description { get; set; }
        
        public string Creator { get; set; }

        public ICollection<LocationViewModel> Route { get; set; }
        
        public ICollection<ImageViewModel> Images { get; set; }

        public ICollection<UserResponseModel> Participants { get; set; }

        public object Test { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Trip, TripResponseModel>("TripDisplay")
                .ForMember(m => m.Creator, opt => opt.MapFrom(t => t.Creator.UserName))
                .ReverseMap();
        }
    }
}