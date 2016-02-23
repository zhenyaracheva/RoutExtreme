namespace RouteExtreme.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using RouteExtreme.Models;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models;
    using Services.Contracts;
    using Web.Controllers;
    using Infrastructure.Mapping;

    [Authorize(Roles = "admin")]
    public class UserController : BaseController
    {
        public UserController(IUserService userService, IChatRoomService chatRoomService)
            : base(userService, chatRoomService)
        {
        }
        
        public ActionResult ManageUsers()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.UserService.GetAll()
                                                     .Where(x => !x.IsDeleted)
                                                     .To<UserViewModel>()
                                                     .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, EditUserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var currentUser = this.UserService.GetById(user.Id)
                                              .FirstOrDefault();

            if (currentUser == null)
            {
                return this.View();
            }

            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;
            currentUser.Email = user.Email;
            currentUser.UserName = user.UserName;

            this.UserService.UpdateUser(currentUser);
            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, User user)
        {
            this.UserService.MarkAsDeleted(user);
            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }
    }
}
