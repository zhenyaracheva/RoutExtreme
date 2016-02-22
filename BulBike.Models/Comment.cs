namespace BulBike.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment : IDeletableEntity, IAuditInfo
    {
        public Comment()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
        }

        [Key]
        public int Id { get; set; }

        [UIHint("MultiLineText")]
        public string Content { get; set; }

        public int TripId { get; set; }

        public virtual Trip Trip { get; set; }

        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
