namespace BulBike.Models
{
    using System;

    public class ChatMessage : IDeletableEntity, IAuditInfo
    {
        public ChatMessage()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
        }

        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public string Message { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
