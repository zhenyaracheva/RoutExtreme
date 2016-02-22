namespace BulBike.Web.Controllers
{
    using BulBike.Models;
    using Microsoft.AspNet.Identity;
    using Models.Comments;
    using Services.Contracts;
    using System.Web.Mvc;

    public class CommentController : BaseController
    {
        private ICommentService commentService;

        public CommentController(ICommentService commentService, IUserService userService, IChatRoomService chatRoomService)
            :base(userService, chatRoomService)
        {
            this.commentService = commentService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(CommentInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var comment = new Comment
            {
                Content = model.Content,
                TripId = model.TripId,
                CreatorId = this.User.Identity.GetUserId()
            };

            this.commentService.Create(comment);

            return this.RedirectToAction("Details", "Trip", new { id = model.TripId });
        }
    }
}