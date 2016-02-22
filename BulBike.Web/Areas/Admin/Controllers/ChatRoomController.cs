namespace BulBike.Web.Areas.Admin.Controllers
{
    using AutoMapper.QueryableExtensions;
    using BulBike.Models;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models.ChatRooms;
    using Services.Contracts;
    using System.Web.Mvc;
    using Web.Controllers;
    using System.Linq;

    [Authorize(Roles = "admin")]
    public class ChatRoomController : BaseController
    {
        public ChatRoomController(IUserService userService, IChatRoomService chatRoomService)
            : base(userService, chatRoomService)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.ChatRoomService.GetAll()
                                                    .ProjectTo<ChatRoomViewModel>()
                                                    .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, InputChatRoomViewModel chatRoom)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var room = this.ChatRoomService.GetAll()
                           .Where(x => x.Id == chatRoom.Id)
                           .FirstOrDefault();

            room.Name = chatRoom.Name;
            this.ChatRoomService.Update(room);

            return Json(new[] { chatRoom }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ChatRoom chatRoom)
        {
            this.ChatRoomService.MarkAsDeleted(chatRoom);
            
            return Json(new[] { chatRoom }.ToDataSourceResult(request, ModelState));
        }
    }
}
