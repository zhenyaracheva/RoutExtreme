namespace BulBike.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using BulBike.Models;
    using Kendo.Mvc.Extensions;
    using Microsoft.AspNet.Identity;
    using Models.TripViewModels;
    using Services.Contracts;

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
            Trip currentTrip = null;

            if (trip != null && ModelState.IsValid)
            {
                var test = trip.Route.Substring(1, trip.Route.Length - 2);
                var route = test.Split(new string[] { "),(" }, StringSplitOptions.RemoveEmptyEntries);
                var locations = new List<Location>();
                var startPos = route[0].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                currentTrip = new Trip
                {
                    CreatorId = this.User.Identity.GetUserId(),
                    Description = trip.Description,
                    StartDate = trip.StartDate,
                    StartPoint = trip.StartPoint,

                };

                this.trips.Add(currentTrip);
                currentTrip.Route = locations;

                for (int i = 0; i < route.Length; i++)
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

            return this.RedirectToAction("Details", new { id = currentTrip.Id });
        }

        [HttpPost]
        [Authorize]
        public ActionResult JoinUser(int id)
        {
            var trip = this.trips.GetById(id)
                .FirstOrDefault();

            if (trip != null)
            {
                var user = this.UserService.GetById(this.User.Identity.GetUserId())
                               .FirstOrDefault();

                trip.Participants.Add(user);
                this.trips.Update(trip);

                var users = trip.Participants
                                    .Select(x => new
                                    {
                                        username = x.UserName,
                                        id = x.Id
                                    })
                                    .ToList();

                return this.Json(users, JsonRequestBehavior.AllowGet);
            }
            else
            {
                throw new Exception("Not Found Trip!");
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult RemoveUserFromTrip(int id)
        {
            var trip = this.trips.GetById(id)
                .FirstOrDefault();

            if (trip != null)
            {
                var user = this.UserService.GetById(this.User.Identity.GetUserId())
                               .FirstOrDefault();

                trip.Participants.Remove(user);
                this.trips.Update(trip);

                var users = trip.Participants
                                   .Select(x => new
                                   {
                                       username = x.UserName,
                                       id = x.Id
                                   })
                                    .ToList();

                return this.Json(users, JsonRequestBehavior.AllowGet);
            }
            else
            {
                throw new Exception("Not Found Trip!");
            }
        }

        public ActionResult Details(int id)
        {
            var trip = this.trips.GetById(id)
                                 .ProjectTo<TripResponseModel>()
                                 .FirstOrDefault();

            //trip.Test = Json(trip.Route, JsonRequestBehavior.AllowGet);
            return View(trip);
        }

        public ActionResult GetTripRoute(int id)
        {
            var trip = this.trips.GetById(id)
                                 .ProjectTo<TripResponseModel>()
                                 .FirstOrDefault();

            return Json(trip.Route, JsonRequestBehavior.AllowGet);
        }

        public ActionResult All(int id = 1, int tripsPerPage = 5)
        {
            var page = id;
            var allTrips = this.trips.GetAll().Count();


            var totalPages = (int)Math.Ceiling(allTrips / ((decimal)tripsPerPage));
            if (page - 1 < 0)
            {
                page = 1;
            }
            else if (page - 1 >= totalPages)
            {
                page = totalPages;
            }
            
            var itemsToSkip = (page - 1) * tripsPerPage;

            var trips = this.trips.GetAll()
                                  .OrderBy(x => x.CreatedOn)
                                  .Skip(itemsToSkip)
                                  .Take(tripsPerPage)
                                  .ProjectTo<TripResponseModel>()
                                  .ToList();
            var tripModel = new TripPagableModel
            {
                CurrentPage = page,
                TotalPages = totalPages,
                AllTrips = trips
            };


            return View(tripModel);
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddImages(int id)
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult AddImages(TripAddImageViewModel tripImages)
        {
            var test = Request.Files.Count;
            var test12 = Request.Files;

            if (tripImages.Images.Count() > 0)
            {

                var trip = this.trips.GetById(tripImages.TripID)
                                     .FirstOrDefault();

                foreach (var uploadedFile in tripImages.Images)
                {
                    if (uploadedFile != null && uploadedFile.ContentLength > 0)
                    {
                        Image image = null;
                        using (var memory = new MemoryStream())
                        {
                            uploadedFile.InputStream.CopyTo(memory);
                            var content = memory.GetBuffer();

                            image = new Image
                            {
                                Content = content,
                                FileExtension = uploadedFile.FileName.Split(new[] { '.' }).Last()
                            };

                            trip.Images.Add(image);
                        }
                    }
                }

                this.trips.Update(trip);
                return this.RedirectToAction("Details", new { id = trip.Id });
            }

            return null;
        }

        public ActionResult UpcommingTrips()
        {
            return View();
        }
    }
}