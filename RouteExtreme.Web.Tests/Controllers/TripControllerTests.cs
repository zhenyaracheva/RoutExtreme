namespace RouteExtreme.Web.Tests.Controllers
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using App_Start;
    using Web.Controllers;
    using Services.Contracts;
    using Moq;
    using RouteExtreme.Models;
    using System.Collections.Generic;
    using TestStack.FluentMVCTesting;
    using System.Linq;
    using Models.TripViewModels;
    using Models.Comments;

    [TestClass]
    public class TripControllerTests
    {
        private AutoMapperConfig autoMapperConfig;

        public TripControllerTests()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(TripController).Assembly);
        }

        [TestMethod]
        public void ActionCreateShoudWorkCorrectly()
        {
            var userServerce = new Mock<IUserService>();
            var chatService = new Mock<IChatRoomService>();
            var tripServerce = new Mock<ITripService>();
            var commentService = new Mock<ICommentService>();

            tripServerce.Setup(x => x.GetAll())
                .Returns(new List<Trip>().AsQueryable());

            var controller = new TripController(userServerce.Object, chatService.Object, tripServerce.Object, commentService.Object);
            controller.WithCallTo(x => x.Create())
                .ShouldRenderView("Create");
        }

        [TestMethod]
        public void ActionGetDetailsShoudWorkCorrectly()
        {
            var userServerce = new Mock<IUserService>();
            var chatService = new Mock<IChatRoomService>();
            var tripServerce = new Mock<ITripService>();
            var commentService = new Mock<ICommentService>();

            tripServerce.Setup(x => x.GetById(1))
                .Returns(new List<Trip>().AsQueryable());

            var controller = new TripController(userServerce.Object, chatService.Object, tripServerce.Object, commentService.Object);
            controller.WithCallTo(x => x.Create())
                .ShouldRenderView("Create");
        }
    }
}
