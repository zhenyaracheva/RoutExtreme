namespace RouteExtreme.Web.Controllers
{
    using Microsoft.AspNet.Identity;
    using RouteExtreme.Models;
    using RouteExtreme.Services.Contracts;
    using System.Linq;
    using System.Web.Mvc;

    [Authorize]
    public class VoteController : Controller
    {
        private IVoteService voteService;

        public VoteController(IVoteService votes)
        {
            this.voteService = votes;
        }

        [HttpPost]
        public ActionResult Vote(int id, int voteType)
        {
            if (voteType > 1)
            {
                voteType = 1;
            }
            if (voteType < -1)
            {
                voteType = -1;
            }

            var userId = this.User.Identity.GetUserId();
            var vote = this.voteService.All()
                                       .FirstOrDefault(x => x.AuthorId == userId && x.TripId == id);

            if (vote == null)
            {
                vote = new Vote
                {
                    AuthorId = userId,
                    TripId = id,
                    Type = (VoteType)voteType
                };
                this.voteService.Add(vote);
            }
            else
            {
                if (vote.Type != (VoteType)voteType)
                {
                    vote.Type = (VoteType)voteType;
                }
                else if (vote.Type == VoteType.Neutral)
                {
                    vote.Type = (VoteType)voteType;
                }

                this.voteService.Update(vote);
            }

            var postVotes = this.voteService.All()
                .Where(x => x.TripId == id)
                .Sum(x => (int)x.Type);

            return this.Json(new { Count = postVotes });
        }
    }
}