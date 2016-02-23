namespace RouteExtreme.Web.Controllers
{
    using Services.Contracts;
    using System.Web.Mvc;

    public class ErrorController : BaseController
    {
        public ErrorController(IUserService users, IChatRoomService chatRooms)
            : base(users, chatRooms)
        {
        }

        public ViewResult Index()
        {
            return this.View("Error");
        }

        public ViewResult NotFound()
        {
            this.Response.StatusCode = 404;
            return this.View();
        }
    }
}