namespace BulBike.Services
{
    using System;
    using Models;
    using BulBike.Services.Contracts;
    using Data.Repositories;

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

        public void Update(Trip trip)
        {
            this.trips.Update(trip);
            this.trips.SaveChanges();
        }
    }
}
