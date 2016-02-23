namespace RouteExtreme.Web.Tests.Routes
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Web.Routing;
    using MvcRouteTester;
    using RouteExtreme.Web.Controllers;

    [TestClass]
    public class ChatRoomRoutes
    {
        [TestMethod]
        public void GetUserChatRooms()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/ChatRoom/GetUserRooms";

            routeCollection
                .ShouldMap(urlForTest)
                .To<ChatRoomController>(x => x.GetUserRooms());
        }
    }
}
