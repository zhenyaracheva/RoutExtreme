namespace BulBike.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public string Message { get; set; }
    }
}
