namespace RouteExtreme.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface ITripService
    {
        void Add(Trip trip);

        void Update(Trip trip);

        IQueryable<Trip> GetAll();

        IQueryable<Trip> GetById(int id);

        void MarkAsDeleted(Trip trip);
    }
}
