namespace RouteExtreme.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Vote : IDeletableEntity, IAuditInfo
    {
        public Vote()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
        }


        public int Id { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int TripId { get; set; }

        public virtual Trip Trip { get; set; }

        public VoteType Type { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
