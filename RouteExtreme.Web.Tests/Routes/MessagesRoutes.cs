using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Routing;
using RouteExtreme.Web.Controllers;
using MvcRouteTester;

namespace RouteExtreme.Web.Tests.Routes
{
    [TestClass]
    public class MessagesRoutes
    {
        [TestMethod]
        public void TestMessagesIndex()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Message/CreateMessage";

            routeCollection
                .ShouldMap(urlForTest)
                .To<MessageController>(x => x.CreateMessage());
        }
    }
}
