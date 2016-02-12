namespace BulBike.Web.Controllers
{
    using System;
    using Models.TripViewModels;
    using Services.Contracts;
    using System.Web.Mvc;
    using System.Collections.Generic;
    using BulBike.Models;
    using Microsoft.AspNet.Identity;

    public class TripController : BaseController
    {
        private ITripService trips;

        public TripController(IUserService users, IChatRoomService chatRoom, ITripService trips)
            : base(users, chatRoom)
        {
            this.trips = trips;
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(TripRequestModel trip)
        {
            if (trip != null && ModelState.IsValid)
            {
                var test = trip.Route.Substring(1, trip.Route.Length - 2);
                var route = test.Split(new string[] { "),(" }, StringSplitOptions.RemoveEmptyEntries);
                var locations = new List<Location>();

                var startPos = route[0].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var startLocation = new Location
                {
                    Latitude = double.Parse(startPos[0]),
                    Longitude = double.Parse(startPos[1])
                };

                var currentTrip = new Trip
                {
                    CreatorId = this.User.Identity.GetUserId(),
                    Description = trip.Description,
                    StartDate = trip.StartDate,
                    StartPoint = startLocation,

                };

                this.trips.Add(currentTrip);
                currentTrip.Route = locations;
                currentTrip.Route.Add(startLocation);

                for (int i = 1; i < route.Length; i++)
                {
                    var current = route[i].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    var location = new Location
                    {
                        Latitude = double.Parse(current[0]),
                        Longitude = double.Parse(current[1])
                    };

                    currentTrip.Route.Add(location);
                }

                this.trips.Update(currentTrip);
            };

            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult All()
        {
            return View();
        }

        public ActionResult UpcommingTrips()
        {
            return View();
        }
    }
}