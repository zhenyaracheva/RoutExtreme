namespace RouteExtreme.Web.Models.TripViewModels
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using RouteExtreme.Web.Models.AccountViewModels;
    using RouteExtreme.Models;
    using RouteExtreme.Web.Infrastructure.Mapping;
    using Comments;
    using System.ComponentModel.DataAnnotations;
    public class TripResponseModel : IMapFrom<Trip>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [StringLength(100000)]
        public string Description { get; set; }

        public string Creator { get; set; }

        [Required]
        [StringLength(50)]
        public string StartPoint { get; set; }

        [Required]
        [StringLength(20)]
        public string ChatRoomName { get; set; }

        public ICollection<LocationViewModel> Route { get; set; }

        public ICollection<ImageViewModel> Images { get; set; }

        public ICollection<UserResponseModel> Participants { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }
        
        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Trip, TripResponseModel>("TripDisplay")
               .ForMember(m => m.Creator, opt => opt.MapFrom(t => t.Creator.UserName))
               .ReverseMap();
        }
    }
}