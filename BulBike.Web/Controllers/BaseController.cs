//namespace BulBike.Web.Controllers
//{
//    using Services;
//    using System.Web.Mvc;

//    public class BaseController : Controller
//    {
//        private IUserService userService;

//        public BaseController(IUserService userService)
//            : base()
//        {
//            this.userService = userService;
//        }
//        // GET: Base
//        public int? GetUserPictureId(string id)
//        {
//            var user = this.userService.GetById(id).ProfilePicId;

//            return user;
//        }
//    }
//}