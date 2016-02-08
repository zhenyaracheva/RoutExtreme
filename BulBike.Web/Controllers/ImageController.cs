namespace BulBike.Web.Controllers
{
    using Services.Contracts;
    using System.Web.Mvc;
    using System.Linq;

    public class ImageController : Controller
    {

        private IImageService images;

        public ImageController(IImageService images) : base()
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