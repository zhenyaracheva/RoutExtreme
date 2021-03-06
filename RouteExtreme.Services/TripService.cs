﻿namespace RouteExtreme.Services
{
    using System.Linq;
    using Data.Repositories;
    using Models;
    using RouteExtreme.Services.Contracts;

    public class TripService : ITripService
    {
        private IRepository<Trip> trips;
        
        public TripService(IRepository<Trip> trips)
        {
            this.trips = trips;
        }

        public void Add(Trip trip)
        {
            this.trips.Add(trip);
            this.trips.SaveChanges();
        }

        public IQueryable<Trip> GetAll()
        {
            return this.trips.All();
        }

        public IQueryable<Trip> GetById(int id)
        {
            return this.trips.All()
                             .Where(x => x.Id == id);
        }

        public void MarkAsDeleted(Trip trip)
        {
            this.trips.MarkAsDeleted(trip);
            this.trips.SaveChanges();
        }

        public void Update(Trip trip)
        {
            this.trips.Update(trip);
            this.trips.SaveChanges();
        }
    }
}
