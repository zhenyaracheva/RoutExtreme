namespace BulBike.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;

    public class User : IdentityUser, IDeletableEntity, IAuditInfo
    {
        private ICollection<ChatRoom> chatRooms;
        private ICollection<Connection> connections;
        private ICollection<Trip> trips;

        public User() : base()
        {
            this.chatRooms = new HashSet<ChatRoom>();
            this.connections = new HashSet<Connection>();
            this.trips = new HashSet<Trip>();
            this.IsDeleted = false;
            this.CreatedOn = DateTime.UtcNow;
        }

        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        public int? ProfilePicId { get; set; }

        public virtual Image ProfilePic { get; set; }

        //public string ConnectionId { get; set; }

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

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
