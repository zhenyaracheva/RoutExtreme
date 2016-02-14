namespace BulBike.Services
{
    using System;
    using Models;
    using BulBike.Services.Contracts;
    using Data.Repositories;
    using System.Linq;

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

        public void Update(Trip trip)
        {
            this.trips.Update(trip);
            this.trips.SaveChanges();
        }
    }
}
