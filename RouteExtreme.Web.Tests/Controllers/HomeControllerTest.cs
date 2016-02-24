using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RouteExtreme.Web;
using RouteExtreme.Web.Controllers;
using RouteExtreme.Services.Contracts;
using Moq;
using TestStack.FluentMVCTesting;
using RouteExtreme.Models;

namespace RouteExtreme.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var userServerce = new Mock<IUserService>();
            var chatService = new Mock<IChatRoomService>();
            var tripServerce = new Mock<ITripService>();
            var commentService = new Mock<ICommentService>();

            var controller = new HomeController(userServerce.Object, chatService.Object, tripServerce.Object);

            controller.WithCallTo(x => x.Index())
                .ShouldRenderView("Index");
        }
        
        [TestMethod]
        public void Chat()
        {
            var userServerce = new Mock<IUserService>();
            var chatService = new Mock<IChatRoomService>();
            var tripServerce = new Mock<ITripService>();
            var commentService = new Mock<ICommentService>();

            var controller = new HomeController(userServerce.Object, chatService.Object, tripServerce.Object);

            controller.WithCallTo(x => x.Chat())
                .ShouldRenderView("Chat");
        }

        [TestMethod]
        public void GetTrips()
        {
            var userServerce = new Mock<IUserService>();
            var chatService = new Mock<IChatRoomService>();
            var tripServerce = new Mock<ITripService>();
            var commentService = new Mock<ICommentService>();

            tripServerce.Setup(x => x.GetAll())
               .Returns(new List<Trip>().AsQueryable());

            var controller = new HomeController(userServerce.Object, chatService.Object, tripServerce.Object);

            controller.WithCallTo(x => x.GetTrips())
                .ShouldReturnJson();
        }
    }
}
