using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Routing;
using MvcRouteTester;
using RouteExtreme.Web.Controllers;

namespace RouteExtreme.Web.Tests.Routes
{
    [TestClass]
    public class ImageRoutes
    {
        [TestMethod]
        public void GetImage()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Image/GetImage/1";

            routeCollection
                .ShouldMap(urlForTest)
                .To<ImageController>(x => x.GetImage(1));
        }
    }
}
