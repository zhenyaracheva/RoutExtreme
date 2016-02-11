namespace BulBike.Web.Controllers
{
    using Models;
    using Services;
    using Services.Contracts;
    using System.Web.Mvc;

    public class EventController : BaseController
    {
        public EventController(IUserService users, IChatRoomService chatRoom)
            : base(users, chatRoom)
        {
        }
        
        // GET: Event
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(LocationViewModel location)
        {
            if (location != null && ModelState.IsValid)
            {

            }


            return View();
        }
    }
}