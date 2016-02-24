namespace RouteExtreme.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class ChatMessage : IDeletableEntity, IAuditInfo
    {
        public ChatMessage()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
        }

        [Key]
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        [Required]
        [StringLength(5000)]
        public string Message { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
