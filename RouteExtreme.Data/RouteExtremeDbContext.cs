namespace RouteExtreme.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using Microsoft.AspNet.Identity.EntityFramework;
    using RouteExtreme.Models;
    
    public class RouteExtremeDbContext : IdentityDbContext<User>, IRouteExtremeDbContext
    {
        public RouteExtremeDbContext()
            : base("RouteExtreme", throwIfV1Schema: false)
        {
        }

        public override IDbSet<User> Users { get; set; }

        public virtual IDbSet<Location> Locations { get; set; }

        public virtual IDbSet<Trip> Trips { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<ChatMessage> ChatMessages { get; set; }

        public virtual IDbSet<ChatRoom> ChatRooms { get; set; }

        public virtual IDbSet<Connection> Connections { get; set; }

        public virtual IDbSet<Vote> Votes { get; set; }
        
        public static RouteExtremeDbContext Create()
        {
            return new RouteExtremeDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
