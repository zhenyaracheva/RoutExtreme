namespace BulBike.Services.Contracts
{
    using Models;
    using System;

    public interface ITripService
    {
        void Add(Trip trip);

        void Update(Trip trip);
    }
}
