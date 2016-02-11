namespace BulBike.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<ChatRoom> chatRooms;

        public User() : base()
        {
            this.chatRooms = new HashSet<ChatRoom>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? ProfilePicId { get; set; }

        public virtual Image ProfilePic { get; set; }

        public string ConnectionId { get; set; }

        public ICollection<ChatRoom> ChatRooms
        {
            get { return this.chatRooms; }
            set { this.chatRooms = value; }
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
