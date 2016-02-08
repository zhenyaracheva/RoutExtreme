namespace BulBike.Data
{
    using BulBike.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System;

    public class BulBikeDbContext : IdentityDbContext<User>, IBulBikeDbContext
    {
        public BulBikeDbContext()
            : base("BulBike", throwIfV1Schema: false)
        {
        }

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
    }
}
