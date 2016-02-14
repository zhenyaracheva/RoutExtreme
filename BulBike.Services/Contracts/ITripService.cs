namespace BulBike.Services.Contracts
{
    using Models;
    using System;
    using System.Linq;

    public interface ITripService
    {
        void Add(Trip trip);

        void Update(Trip trip);

        IQueryable<Trip> GetAll();

        IQueryable<Trip> GetById(int id);
    }
}
