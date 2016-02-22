namespace BulBike.Models
{
    using System;
    using System.Collections.Generic;

    public class Trip : IDeletableEntity, IAuditInfo
    {
        private ICollection<Location> route;
        private ICollection<Image> images;
        private ICollection<User> participants;

        public Trip()
        {
            this.route = new HashSet<Location>();
            this.images = new HashSet<Image>();
            this.participants = new HashSet<User>();
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
        }

        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Description { get; set; }

        public string StartPoint { get; set; }

        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

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
    }
}
