namespace BulBike.Web.Models.TripViewModels
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using BulBike.Web.Models.AccountViewModels;
    using BulBike.Models;
    using BulBike.Web.Infrastructure.Mapping;
    using Comments;
    public class TripResponseModel : IMapFrom<Trip>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Description { get; set; }

        public string Creator { get; set; }

        public string StartPoint { get; set; }

        public ICollection<LocationViewModel> Route { get; set; }

        public ICollection<ImageViewModel> Images { get; set; }

        public ICollection<UserResponseModel> Participants { get; set; }
        
        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Trip, TripResponseModel>("TripDisplay")
                .ForMember(m => m.Creator, opt => opt.MapFrom(t => t.Creator.UserName))
                .ReverseMap();
        }
    }
}