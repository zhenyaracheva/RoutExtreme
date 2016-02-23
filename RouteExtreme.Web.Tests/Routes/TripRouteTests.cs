using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcRouteTester;
using RouteExtreme.Web.Controllers;
using System.Web.Routing;

namespace RouteExtreme.Web.Tests.Routes
{

    [TestClass]
    public class TripRouteTests
    {
        [TestMethod]
        public void TestTripDonateGiftByIdWithValue()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Trip/Details/1?page=1";

            routeCollection
                .ShouldMap(urlForTest)
                .To<TripController>(x => x.Details(1, 1));
        }

        [TestMethod]
        public void TestTriptLessThanZeroPage()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Trip/Details/1?page=0";

            routeCollection
                .ShouldMap(urlForTest)
                .To<TripController>(x => x.Details(1, 0));
        }

        [TestMethod]
        public void TestAllTripsUrlParameters()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Trip/All/1?orderBy=creator&search=test";

            routeCollection
                .ShouldMap(urlForTest)
                .To<TripController>(x => x.All("creator","test",1));
        }

        [TestMethod]
        public void TestAllTripsNoSearhParameter()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Trip/All/1?orderBy=creator&search=";

            routeCollection
                .ShouldMap(urlForTest)
                .To<TripController>(x => x.All("creator", "", 1));
        }

        [TestMethod]
        public void TestTripCreateAction()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Trip/Create";

            routeCollection
                .ShouldMap(urlForTest)
                .To<TripController>(x => x.Create());
        }

        [TestMethod]
        public void TestTripJoinUser()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Trip/JoinUser/5";

            routeCollection
                .ShouldMap(urlForTest)
                .To<TripController>(x => x.JoinUser(5));
        }

        [TestMethod]
        public void TestTripRemoveUserFromTrip()
        {
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            var urlForTest = "/Trip/RemoveUserFromTrip/5";

            routeCollection
                .ShouldMap(urlForTest)
                .To<TripController>(x => x.RemoveUserFromTrip(5));
        }
    }
}
