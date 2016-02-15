namespace BulBike.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        private ICollection<ChatRoom> chatRooms;
        private ICollection<Trip> trips;

        public User() : base()
        {
            this.chatRooms = new HashSet<ChatRoom>();
            this.trips = new HashSet<Trip>();
        }

        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        public int? ProfilePicId { get; set; }

        public virtual Image ProfilePic { get; set; }

        public string ConnectionId { get; set; }

        public ICollection<ChatRoom> ChatRooms
        {
            get { return this.chatRooms; }
            set { this.chatRooms = value; }
        }

        public ICollection<Trip> Trips
        {
            get { return this.trips; }
            set { this.trips = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
