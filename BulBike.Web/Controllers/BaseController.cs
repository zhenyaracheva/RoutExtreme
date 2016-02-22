namespace BulBike.Web.Controllers
{
    using BulBike.Models;
    using Services;
    using Services.Contracts;
    using System.Linq;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;

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
                           .FirstOrDefault()
                           .ProfilePicId;

            return user;
        }

        public ICollection<ChatRoom> GetRooms()
        {
            return this.chatRoomsService.GetAll()
                                        .ToList();
        }
    }
}