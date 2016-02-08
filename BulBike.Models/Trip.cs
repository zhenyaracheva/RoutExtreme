namespace BulBike.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Trip
    {
        private ICollection<Location> points;
        private ICollection<User> joinedUsers;
        private ICollection<Image> images;

        public Trip()
        {
            this.points = new HashSet<Location>();
            this.joinedUsers = new HashSet<User>();
            this.images = new HashSet<Image>();
        }
        
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public int StartPointId { get; set; }

        public virtual Location StartPoint { get; set; }

        public int EndPointId { get; set; }

        public virtual Location EndPoint { get; set; }

        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public virtual ICollection<Location> Points
        {
            get { return this.points; }
            set { this.points = value; }
        }

        public virtual ICollection<User> JoinedUsers
        {
            get { return this.joinedUsers; }
            set { this.joinedUsers = value; }
        }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }
    }
}
