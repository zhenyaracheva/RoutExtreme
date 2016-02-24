using RouteExtreme.Models;
using RouteExtreme.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace RouteExtreme.Web.Models
{
    public class VoteViewModel : IMapFrom<Vote>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int Type { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Vote, VoteViewModel>("TripDisplay")
             .ForMember(m => m.Type, opt => opt.MapFrom(t => (int)t.Type))
             .ReverseMap();
        }
    }
}