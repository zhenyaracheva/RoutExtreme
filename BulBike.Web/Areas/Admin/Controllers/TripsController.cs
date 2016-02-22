namespace BulBike.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using BulBike.Models;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models.Trips;
    using Services.Contracts;
    using Web.Controllers;

    [Authorize(Roles = "admin")]
    public class TripsController : BaseController
    {
        private ITripService tripService;

        public TripsController(ITripService tripService, IUserService userService, IChatRoomService chatRoomService)
            : base(userService, chatRoomService)
        {
            this.tripService = tripService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.tripService.GetAll()
                                                     .Where(x => !x.IsDeleted)
                                                     .ProjectTo<TripViewModel>()
                                                     .ToDataSourceResult(request);

            return Json(result);
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, Trip trip)
        {
            this.tripService.MarkAsDeleted(trip);

            return Json(new[] { trip }.ToDataSourceResult(request, ModelState));
        }
    }
}
