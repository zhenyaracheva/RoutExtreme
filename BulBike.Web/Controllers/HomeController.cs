namespace BulBike.Web.Controllers
{
    using BulBike.Services;
    using System.Web.Mvc;

    public class HomeController : BaseController
    {
        public HomeController(IUserService userService)
            : base(userService)
        {
        }

        public ActionResult Index()
        {
            return View();
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