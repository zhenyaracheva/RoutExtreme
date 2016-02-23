namespace RouteExtreme.Web.Tests.Routes
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Web.Routing;
    using MvcRouteTester;
    using RouteExtreme.Web.Controllers;

    [TestClass]
    public class HomeControllerRoutes
    {
        [TestMethod]
        public void TestHomeIndex()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Home/Index";

            routeCollection
                .ShouldMap(urlForTest)
                .To<HomeController>(x => x.Index());
        }

        [TestMethod]
        public void HomeGetTrips()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Home/GetTrips";

            routeCollection
                .ShouldMap(urlForTest)
                .To<HomeController>(x => x.GetTrips());
        }
    }
}
