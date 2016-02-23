namespace RouteExtreme.Web.Controllers
{
    using Services.Contracts;
    using System.Web.Mvc;
    using System.Linq;
    
    using System;
    using Models.TripViewModels;
    using Infrastructure.Mapping;
    public class HomeController : BaseController
    {
        private ITripService trips;

        public HomeController(IUserService userService, IChatRoomService chatRoom, ITripService trips)
            : base(userService, chatRoom)
        {
            this.trips = trips;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult GetTrips()
        {
            var upcommin = this.trips.GetAll()
                                     .Where(x => !x.IsDeleted && x.StartDate > DateTime.UtcNow)
                                     .To<TripResponseModel>()
                                     .ToList();



            return this.Json(upcommin, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Chat()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}