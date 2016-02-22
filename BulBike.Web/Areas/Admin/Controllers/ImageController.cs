﻿using System;
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

namespace BulBike.Web.Areas.Admin.Controllers
{
    public class ImageController : Controller
    {
        private BulBikeDbContext db = new BulBikeDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Images_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Image> images = db.Images;
            DataSourceResult result = images.ToDataSourceResult(request, image => new {
                Id = image.Id,
                Content = image.Content,
                FileExtension = image.FileExtension,
                ModifiedOn = image.ModifiedOn,
                CreatedOn = image.CreatedOn,
                DeletedOn = image.DeletedOn,
                IsDeleted = image.IsDeleted
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Images_Destroy([DataSourceRequest]DataSourceRequest request, Image image)
        {
            if (ModelState.IsValid)
            {
                var entity = new Image
                {
                    Id = image.Id,
                    Content = image.Content,
                    FileExtension = image.FileExtension,
                    ModifiedOn = image.ModifiedOn,
                    CreatedOn = image.CreatedOn,
                    DeletedOn = image.DeletedOn,
                    IsDeleted = image.IsDeleted
                };

                db.Images.Attach(entity);
                db.Images.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { image }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
