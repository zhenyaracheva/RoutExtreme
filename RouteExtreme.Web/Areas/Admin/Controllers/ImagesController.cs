namespace RouteExtreme.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using RouteExtreme.Models;
    using RouteExtreme.Web.Controllers;
    using RouteExtreme.Services.Contracts;
    using RouteExtreme.Data;
    using AutoMapper.QueryableExtensions;
    using RouteExtreme.Web.Areas.Admin.Models;
    using Infrastructure.Mapping;
    [Authorize(Roles = "admin")]
    public class ImagesController : BaseController
    {
        private RouteExtremeDbContext db = new RouteExtremeDbContext();
        private IImageService imageService;

        public ImagesController(IUserService userService, IChatRoomService chatRoomService, IImageService imageService)
            : base(userService, chatRoomService)
        {
            this.imageService = imageService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Images_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.imageService.GetAll()
                                                    .To<ImageViewModel>()
                                                    .ToDataSourceResult(request);
            
            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Images_Destroy([DataSourceRequest]DataSourceRequest request, Image image)
        {
            this.imageService.MarkAsDeleted(image);

            return Json(new[] { image }.ToDataSourceResult(request, ModelState));
        }
    }
}
