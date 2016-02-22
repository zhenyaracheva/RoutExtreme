namespace BulBike.Web.Models.Comments
{
    public class CommentInputModel
    {
        public string Content { get; set; }

        public int TripId { get; set; }
        
        public string CreatorId { get; set; }
    }
}