namespace BulBike.Web.Controllers
{
    using Services.Contracts;
    using System.Web.Mvc;
    using System.Linq;

    [Authorize]
    public class ChatRoomController : Controller
    {
        private IChatRoomService chatRooms;

        public ChatRoomController(IChatRoomService chatRooms)
        {
            this.chatRooms = chatRooms;
        }

        [HttpGet]
        public ActionResult GetUserRooms()
        {
            var result = this.chatRooms.RoomsByUsername(this.User.Identity.Name)
                                       .ToList();


            return this.Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}