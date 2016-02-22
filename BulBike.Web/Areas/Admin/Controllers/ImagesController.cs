using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using BulBike.Models;
using BulBike.Web.Controllers;
using BulBike.Services.Contracts;
using BulBike.Data;
using AutoMapper.QueryableExtensions;
using BulBike.Web.Areas.Admin.Models;

namespace BulBike.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class ImagesController : BaseController
    {
        private BulBikeDbContext db = new BulBikeDbContext();
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
                                                    .ProjectTo<ImageViewModel>()
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
