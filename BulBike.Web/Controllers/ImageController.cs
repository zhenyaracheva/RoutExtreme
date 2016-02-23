namespace BulBike.Web.Controllers
{
    using Services.Contracts;
    using System.Web.Mvc;
    using System.Linq;
    using Services;
    public class ImageController : BaseController
    {
        private IImageService images;

        public ImageController(IImageService images, IUserService users, IChatRoomService chatRoom)
            : base(users, chatRoom)
        {
            this.images = images;
        }

        public ActionResult GetImage(int id)
        {
            var image = this.images.GetById(id);
            if (image == null)
            {
                return null;
            }

            var imageData = image.Content;
            return File(imageData, "image/jpg");
        }
    }
}