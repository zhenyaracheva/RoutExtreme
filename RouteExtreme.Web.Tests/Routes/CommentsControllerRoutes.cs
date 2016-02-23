namespace RouteExtreme.Web.Tests.Routes
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MvcRouteTester;
    using RouteExtreme.Web.Controllers;
    using System.Web.Routing;

    [TestClass]
    public class CommentsControllerRoutes
    {
        [TestMethod]
        public void Comment()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Comment/Index";

            routeCollection
                .ShouldMap(urlForTest)
                .To<CommentController>(x => x.Index());
        }
    }
}
