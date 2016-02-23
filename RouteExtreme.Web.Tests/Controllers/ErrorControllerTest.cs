namespace RouteExtreme.Web.Tests.Controllers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RouteExtreme.Web.Controllers;
    using System.Web.Mvc;
    using System.Web;
    using Moq;
    using Services;
    using Data.Repositories;
    using RouteExtreme.Models;
    using Data;
    using TestStack.FluentMVCTesting;

    [TestClass]
    public class ErrorControllerTest
    {
        [TestMethod]
        public void ActionNotFoundShoudReturnPageNotFoundView()
        {
            var mockHttpContext = new Mock<HttpContextBase>();
            var response = new Mock<HttpResponseBase>();
            mockHttpContext.SetupGet(x => x.Response).Returns(response.Object);
            var db = new RouteExtremeDbContext();
            var repoUsers = new Repository<User>(db);
            var repoChat = new Repository<ChatRoom>(db);

            var controller = new ErrorController(new UserService(repoUsers),new ChatRoomService(repoChat))
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = mockHttpContext.Object
                }
            };

            controller.WithCallTo(x => x.NotFound())
                .ShouldRenderView("NotFound");
        }
    }
}
