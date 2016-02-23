namespace RouteExtreme.Web.Controllers
{
    using RouteExtreme.Services;
    using RouteExtreme.Services.Contracts;
    using System.Web.Mvc;

    public class MessageController : BaseController
    {

        public MessageController(IUserService users, IChatRoomService chatRoom)
            : base(users, chatRoom)
        {
        }

        public ActionResult CreateMessage()
        {
            return View();
        }
    }
}