namespace BulBike.Web.Areas.Admin.Controllers
{
    using AutoMapper.QueryableExtensions;
    using BulBike.Models;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models.ChatRooms;
    using Services.Contracts;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using Web.Controllers;

    public class ChatRoomController : BaseController
    {
        public ChatRoomController( IUserService userService, IChatRoomService chatRoomService)
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
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ChatRoom chatRoom)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var entity = new ChatRoom
            {
               
            };

            //this.ChatRoomService.Add(entity);
            

            return Json(new[] { chatRoom }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ChatRoom chatRoom)
        {
            if (ModelState.IsValid)
            {
                var entity = new ChatRoom
                {
                    Id = chatRoom.Id,
                    ConnectionId = chatRoom.ConnectionId,
                    Name = chatRoom.Name,
                    ModifiedOn = chatRoom.ModifiedOn,
                    CreatedOn = chatRoom.CreatedOn,
                    DeletedOn = chatRoom.DeletedOn,
                    IsDeleted = chatRoom.IsDeleted
                };

                //db.ChatRooms.Attach(entity);
                //db.Entry(entity).State = EntityState.Modified;
                //db.SaveChanges();
            }

            return Json(new[] { chatRoom }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, ChatRoom chatRoom)
        {
            if (ModelState.IsValid)
            {
                var entity = new ChatRoom
                {
                    Id = chatRoom.Id,
                    ConnectionId = chatRoom.ConnectionId,
                    Name = chatRoom.Name,
                    ModifiedOn = chatRoom.ModifiedOn,
                    CreatedOn = chatRoom.CreatedOn,
                    DeletedOn = chatRoom.DeletedOn,
                    IsDeleted = chatRoom.IsDeleted
                };

                //db.ChatRooms.Attach(entity);
                //db.ChatRooms.Remove(entity);
                //db.SaveChanges();
            }

            return Json(new[] { chatRoom }.ToDataSourceResult(request, ModelState));
        }
    }
}
