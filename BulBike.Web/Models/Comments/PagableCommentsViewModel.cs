namespace BulBike.Web.Models.Comments
{
    using BulBike.Web.Models.TripViewModels;

    public class PagableCommentsViewModel : PagableViewModel<CommentViewModel>
    {
        public TripResponseModel Trip { get; set; }
    }
}