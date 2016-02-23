namespace RouteExtreme.Web.Controllers
{
    using RouteExtreme.Services;
    using Services.Contracts;
    using System.Web.Mvc;
    using System.Linq;

    using AutoMapper.QueryableExtensions;
    using System;
    using Models.TripViewModels;
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
                                     .ProjectTo<TripResponseModel>()
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

        //public int? GetUserPictureId(string id)
        //{
        //    var user = this.userService.GetById(id).ProfilePicId;

        //    return user;
        //}
    }
}