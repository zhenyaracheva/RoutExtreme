using BulBike.Models;
using BulBike.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Web.Mvc;

namespace BulBike.Web.Areas.Admin.Models.ChatRooms
{
    public class ChatRoomViewModel : IMapFrom<ChatRoom>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}