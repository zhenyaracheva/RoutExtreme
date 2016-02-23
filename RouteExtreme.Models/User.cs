namespace RouteExtreme.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser, IDeletableEntity, IAuditInfo
    {
        private ICollection<ChatRoom> chatRooms;
        private ICollection<Connection> connections;
        private ICollection<Trip> trips;
        private ICollection<Comment> comments;

        public User() : base()
        {
            this.chatRooms = new HashSet<ChatRoom>();
            this.connections = new HashSet<Connection>();
            this.trips = new HashSet<Trip>();
            this.comments = new HashSet<Comment>();
            this.IsDeleted = false;
            this.CreatedOn = DateTime.UtcNow;
        }

        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        public int? ProfilePicId { get; set; }

        public virtual Image ProfilePic { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<ChatRoom> ChatRooms
        {
            get { return this.chatRooms; }
            set { this.chatRooms = value; }
        }

        public virtual ICollection<Trip> Trips
        {
            get { return this.trips; }
            set { this.trips = value; }
        }

        public virtual ICollection<Connection> Connections
        {
            get { return this.connections; }
            set { this.connections = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
