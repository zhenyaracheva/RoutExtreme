namespace BulBike.Web.Controllers
{
    using Services.Contracts;
    using System.Web.Mvc;
    using System.Linq;
    using Services;
    public class ImageController : BaseController
    {
        private IImageService images;

        public ImageController(IImageService images, IUserService users)
            : base(users)
        {
            this.images = images;
        }

        public ActionResult GetImage(int id)
        {
            var imageData = this.images.GetById(id).Content;
            return File(imageData, "image/jpg");
        }
    }
}