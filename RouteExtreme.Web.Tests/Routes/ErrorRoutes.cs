namespace RouteExtreme.Web.Tests.Routes
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Web.Routing;
    using MvcRouteTester;
    using RouteExtreme.Web.Controllers;

    [TestClass]
    public class ErrorRoutes
    {
        [TestMethod]
        public void NotFound()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Error/NotFound";

            routeCollection
                .ShouldMap(urlForTest)
                .To<ErrorController>(x => x.NotFound());
        }
    }
}
