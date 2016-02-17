namespace BulBike.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Trip
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
        }

        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Description { get; set; }

        public string StartPoint { get; set; }
        
        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }

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
