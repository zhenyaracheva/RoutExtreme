using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteExtreme.Services.Contracts;
using Moq;
using RouteExtreme.Web.Controllers;
using TestStack.FluentMVCTesting;
using RouteExtreme.Models;

namespace RouteExtreme.Web.Tests.Controllers
{
    [TestClass]
    public class ComentControllerTests
    {
        [TestMethod]
        public void Index()
        {
            var userServerce = new Mock<IUserService>();
            var chatService = new Mock<IChatRoomService>();
            var tripServerce = new Mock<ITripService>();
            var commentService = new Mock<ICommentService>();
            
            var controller = new CommentController(commentService.Object, userServerce.Object, chatService.Object);
            controller.WithCallTo(x => x.Index())
                .ShouldRenderView("Index");
        }
    }
}
