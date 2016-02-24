namespace RouteExtreme.Services
{
    using System;
    using System.Linq;
    using Models;
    using RouteExtreme.Services.Contracts;
    using Data.Repositories;

    public class VoteService : IVoteService
    {
        private IRepository<Vote> votes;

        public VoteService(IRepository<Vote> votes)
        {
            this.votes = votes;
        }

        public void Add(Vote vote)
        {
            this.votes.Add(vote);
            this.votes.SaveChanges();
        }

        public IQueryable<Vote> All()
        {
            return this.votes.All()
                             .Where(x => !x.IsDeleted);
        }

        public void Update(Vote vote)
        {
            this.votes.Update(vote);
            this.votes.SaveChanges();
        }
    }
}
