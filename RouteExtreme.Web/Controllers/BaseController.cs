﻿namespace RouteExtreme.Web.Controllers
{
    using RouteExtreme.Models;
    using Services;
    using Services.Contracts;
    using System.Linq;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class BaseController : Controller
    {
        private IUserService userService;
        private IChatRoomService chatRoomsService;

        public BaseController(IUserService userService, IChatRoomService chatRoomService)
            : base()
        {
            this.userService = userService;
            this.chatRoomsService = chatRoomService;
        }

        public IChatRoomService ChatRoomService
        {
            get
            {
                return this.chatRoomsService;
            }
            private set
            {
                this.chatRoomsService = value;
            }
        }

        public IUserService UserService
        {
            get
            {
                return this.userService;
            }
            private set
            {
                this.userService = value;
            }
        }

        public int? GetUserPictureId(string id)
        {
            var user = this.userService.GetById(id)
                           .FirstOrDefault();

            if (user.ProfilePic == null)
            {
                return null;
            }

            if (user.ProfilePic.IsDeleted)
            {
                return null;
            }

            return user.ProfilePicId;
        }

        public ICollection<ChatRoom> GetRooms()
        {
            return this.chatRoomsService.GetAll()
                                        .ToList();
        }
    }
}