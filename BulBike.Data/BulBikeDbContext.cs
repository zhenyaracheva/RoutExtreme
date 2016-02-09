namespace BulBike.Data
{
    using BulBike.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Microsoft.AspNet.Identity;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class BulBikeDbContext : IdentityDbContext<User>, IBulBikeDbContext
    {
        public BulBikeDbContext()
            : base("BulBike", throwIfV1Schema: false)
        {
        }

        public override IDbSet<User> Users { get; set; }

        public virtual IDbSet<Location> Locations { get; set; }

        public virtual IDbSet<Trip> Trips { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<ChatMessage> ChatMessages { get; set; }

        public static BulBikeDbContext Create()
        {
            return new BulBikeDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        //public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
        //    // Add custom user claims here
        //    return userIdentity;
        //}

        //public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        //{
        //    return Task.FromResult(GenerateUserIdentity(manager));
        //}
    }
}
