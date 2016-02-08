namespace BulBike.Web.Controllers
{
    using Models;
    using System.Web.Mvc;

    public class EventController : Controller
    {
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