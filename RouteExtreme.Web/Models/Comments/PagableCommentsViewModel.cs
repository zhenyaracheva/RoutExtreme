namespace RouteExtreme.Web.Models.Comments
{
    using RouteExtreme.Web.Models.TripViewModels;

    public class PagableCommentsViewModel : PagableViewModel<CommentViewModel>
    {
        public TripResponseModel Trip { get; set; }
    }
}