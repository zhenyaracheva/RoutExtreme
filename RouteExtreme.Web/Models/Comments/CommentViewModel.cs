namespace RouteExtreme.Web.Models.Comments
{
    using RouteExtreme.Models;
    using Infrastructure.Mapping;
    using System;
    using AutoMapper;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public string Content { get; set; }
        
        public string Creator { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>("CommentDisplay")
                .ForMember(m => m.Creator, opt => opt.MapFrom(t => t.Creator.UserName))
                .ReverseMap();
        }
    }
}