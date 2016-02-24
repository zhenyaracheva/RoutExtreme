namespace RouteExtreme.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Trip : IDeletableEntity, IAuditInfo
    {
        private ICollection<Location> route;
        private ICollection<Image> images;
        private ICollection<User> participants;
        private ICollection<Comment> comments;
        private ICollection<Vote> votes;

        public Trip()
        {
            this.route = new HashSet<Location>();
            this.images = new HashSet<Image>();
            this.participants = new HashSet<User>();
            this.comments = new HashSet<Comment>();
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
            this.votes = new HashSet<Vote>();
        }

        [Key]
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [StringLength(100000)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string StartPoint { get; set; }

        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Required]
        [StringLength(20)]
        public string ChatRoomName { get; set; }

        public virtual ICollection<Location> Route
        {
            get { return this.route; }
            set { this.route = value; }
        }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }

        public virtual ICollection<User> Participants
        {
            get { return this.participants; }
            set { this.participants = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }
    }
}
