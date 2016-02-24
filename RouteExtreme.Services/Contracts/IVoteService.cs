namespace RouteExtreme.Services.Contracts
{
    using Models;
    using System.Linq;

    public interface IVoteService
    {
        IQueryable<Vote> All();

        void Add(Vote vote);

        void Update(Vote vote);
    }
}
