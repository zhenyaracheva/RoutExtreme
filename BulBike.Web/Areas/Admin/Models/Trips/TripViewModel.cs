namespace BulBike.Web.Areas.Admin.Models.Trips
{
    using BulBike.Models;
    using BulBike.Web.Infrastructure.Mapping;
    using System;
    using AutoMapper;
    using System.Web.Mvc;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class TripViewModel : IMapFrom<Trip>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        
        public string Description { get; set; }

        [Display(Name = "Start Point")]
        public string StartPoint { get; set; }

        [ScaffoldColumn(false)]
        public  string Creator { get; set; }
        
        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Trip, TripViewModel>("TripDisplay")
               .ForMember(m => m.Creator, opt => opt.MapFrom(t => t.Creator.UserName))
               .ReverseMap();
        }
    }
}