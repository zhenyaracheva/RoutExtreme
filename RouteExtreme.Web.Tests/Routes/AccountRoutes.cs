using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Routing;
using RouteExtreme.Web.Controllers;
using MvcRouteTester;

namespace RouteExtreme.Web.Tests.Controllers
{
    [TestClass]
    public class AccountRoutes
    {
        [TestMethod]
        public void UserDetails()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Account/UserDetails/test";

            routeCollection
                .ShouldMap(urlForTest)
                .To<AccountController>(x => x.UserDetails("test"));
        }
        
    }
}
