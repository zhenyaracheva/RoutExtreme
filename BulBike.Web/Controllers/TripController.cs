﻿namespace BulBike.Web.Controllers
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
    using Models.Comments;

    public class TripController : BaseController
    {
        private ITripService trips;
        private ICommentService comments;

        public TripController(IUserService users, IChatRoomService chatRoom, ITripService trips, ICommentService comments)
            : base(users, chatRoom)
        {
            this.trips = trips;
            this.comments = comments;
            this.ViewBag.Creator = "asc";


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

        public ActionResult Details(int id, int page = 1)
        {
            var trip = this.trips.GetById(id)
                                 .ProjectTo<TripResponseModel>()
                                 .FirstOrDefault();

            trip.Participants = trip.Participants
                                                .Where(x => !x.IsDeleted)
                                                .ToList();
            var commentsPerPage = 5;




            var allComments = trip.Comments.Count();

            var totalPages = (int)Math.Ceiling(allComments / ((decimal)commentsPerPage));

            if (page - 1 >= totalPages)
            {
                page = totalPages;
            }

            if (page - 1 < 0)
            {
                page = 1;
            }

            var itemsToSkip = (page - 1) * commentsPerPage;
            var comments = this.comments.GetAll()
                                      .Where(x => x.TripId == id)
                                      .OrderByDescending(x => x.CreatedOn)
                                      .Skip(itemsToSkip)
                                      .Take(commentsPerPage)
                                      .ProjectTo<CommentViewModel>()
                                      .ToList();
            var pagableComments = new PagableCommentsViewModel
            {
                All = comments,
                CurrentPage = page,
                TotalPages = totalPages,
                Trip = trip
            };

            return View(pagableComments);
        }

        public ActionResult GetTripRoute(int id)
        {
            var trip = this.trips.GetById(id)
                                 .ProjectTo<TripResponseModel>()
                                 .FirstOrDefault();

            return Json(trip.Route, JsonRequestBehavior.AllowGet);
        }

        public ActionResult All(string orderBy, string search, int id = 1)
        {
            var page = id;
            var allTrips = this.trips.GetAll().Count();
            var tripsPerPage = 5;

            this.ViewBag.StartPoint = this.ViewBag.StartPoint == "asc" ? "desc" : "asc";

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

            IList<TripResponseModel> trips = new List<TripResponseModel>();

            if (!string.IsNullOrEmpty(search))
            {
                allTrips = this.trips.GetAll()
                                     .Where(x => x.Creator.UserName.Contains(search) || x.StartPoint.Contains(search)).Count();
                totalPages = (int)Math.Ceiling(allTrips / ((decimal)tripsPerPage));
                search = search.ToLower();
                trips = this.trips.GetAll()
                                  .Where(x => x.Creator.UserName.ToLower().Contains(search) ||
                                            x.StartPoint.ToLower().Contains(search))
                                   .OrderBy(o => o.StartDate)
                                   .Skip(itemsToSkip)
                                   .Take(tripsPerPage)
                                   .ProjectTo<TripResponseModel>()
                                   .ToList();
            }
            else if (!string.IsNullOrEmpty(orderBy))
            {
                if (orderBy == "creator")
                {
                    var creator = this.Session["creator"] as string;
                    if (creator == null)
                    {
                        creator = "asc";
                    }

                    if (creator == "asc")
                    {
                        trips = this.trips.GetAll()
                                .OrderBy(x => x.Creator.UserName)
                                .ThenBy(x => x.CreatedOn)
                                .Skip(itemsToSkip)
                                .Take(tripsPerPage)
                                .ProjectTo<TripResponseModel>()
                                .ToList();
                    }
                    else
                    {
                        trips = this.trips.GetAll()
                                .OrderByDescending(x => x.Creator.UserName)
                                .ThenBy(x => x.CreatedOn)
                                .Skip(itemsToSkip)
                                .Take(tripsPerPage)
                                .ProjectTo<TripResponseModel>()
                                .ToList();
                    }

                    if (page == 1)
                    {
                        this.Session["creator"] = creator == "asc" ? "desc" : "asc";
                    }

                }
                else if (orderBy == "createdOn")
                {
                    var createdOn = this.Session["createdOn"] as string;
                    if (createdOn == null)
                    {
                        createdOn = "des";
                    }

                    if (createdOn == "asc")
                    {
                        trips = this.trips.GetAll()
                                .OrderBy(x => x.CreatedOn)
                                .ThenBy(x => x.Creator.UserName)
                                .Skip(itemsToSkip)
                                .Take(tripsPerPage)
                                .ProjectTo<TripResponseModel>()
                                .ToList();
                    }
                    else
                    {
                        trips = this.trips.GetAll()
                                .OrderByDescending(x => x.CreatedOn)
                                .ThenBy(x => x.Creator.UserName)
                                .Skip(itemsToSkip)
                                .Take(tripsPerPage)
                                .ProjectTo<TripResponseModel>()
                                .ToList();
                    }

                    this.Session["createdOn"] = createdOn == "asc" ? "desc" : "asc";
                }
                else if (orderBy == "startPoint")
                {
                    var creator = this.Session["startPoint"] as string;
                    if (creator == null)
                    {
                        creator = "asc";
                    }

                    trips = this.OrderByStartPoint(creator, itemsToSkip, tripsPerPage);

                    this.Session["startPoint"] = creator == "asc" ? "desc" : "asc";
                }
                else if (orderBy == "startPointp")
                {
                    var creator = this.Session["startPoint"] as string;
                    creator = creator == "asc" ? "desc" : "asc";
                    trips = this.OrderByStartPoint(creator, itemsToSkip, tripsPerPage);
                }

            }
            else
            {
                trips = this.trips.GetAll()
                                         .OrderBy(x => x.CreatedOn)
                                         .Skip(itemsToSkip)
                                         .Take(tripsPerPage)
                                         .ProjectTo<TripResponseModel>()
                                         .ToList();
            }


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

        public ActionResult AddComment(CommentInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var comment = new Comment
            {
                Content = model.Content,
                TripId = model.TripId,
                CreatorId = this.User.Identity.GetUserId()
            };

            var trip = this.trips.GetById(comment.TripId)
                                  .FirstOrDefault();

            if (trip == null)
            {
                throw new Exception("Not Existing Trip!");
            }

            trip.Comments.Add(comment);
            this.trips.Update(trip);
            return this.RedirectToAction("Details", "Trip", new { id = model.TripId });
        }

        private IList<TripResponseModel> OrderByStartPoint(string way, int itemsToSkip, int tripsPerPage)
        {
            if (way == "asc")
            {
                return this.trips.GetAll()
                        .OrderBy(x => x.StartPoint)
                        .ThenBy(x => x.CreatedOn)
                        .Skip(itemsToSkip)
                        .Take(tripsPerPage)
                        .ProjectTo<TripResponseModel>()
                        .ToList();
            }
            else
            {
                return this.trips.GetAll()
                        .OrderByDescending(x => x.StartPoint)
                        .ThenBy(x => x.CreatedOn)
                        .Skip(itemsToSkip)
                        .Take(tripsPerPage)
                        .ProjectTo<TripResponseModel>()
                        .ToList();
            }
        }
    }
}