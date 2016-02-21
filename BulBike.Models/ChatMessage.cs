namespace BulBike.Models
{
    using System;

    public class ChatMessage
    {
        public ChatMessage()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public string Message { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
