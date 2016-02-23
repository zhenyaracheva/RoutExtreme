namespace RouteExtreme.Web.Areas.Admin.Models.Trips
{
    using RouteExtreme.Models;
    using RouteExtreme.Web.Infrastructure.Mapping;
    using System;
    using AutoMapper;
    using System.Web.Mvc;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using Web.Models;

    public class TripViewModel : IMapFrom<Trip>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string RouteStr { get; set; }

        public ICollection<LocationViewModel> Route { get; set; }

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