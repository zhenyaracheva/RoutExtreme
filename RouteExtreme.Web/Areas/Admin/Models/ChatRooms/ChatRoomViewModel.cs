using RouteExtreme.Models;
using RouteExtreme.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Web.Mvc;

namespace RouteExtreme.Web.Areas.Admin.Models.ChatRooms
{
    public class ChatRoomViewModel : IMapFrom<ChatRoom>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}