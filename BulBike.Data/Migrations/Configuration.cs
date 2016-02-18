namespace BulBike.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<BulBike.Data.BulBikeDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BulBike.Data.BulBikeDbContext context)
        {
            context.Configuration.LazyLoadingEnabled = true;

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<User>(new UserStore<User>(context));

            userManager.PasswordValidator = new MinimumLengthValidator(5);

            if (!roleManager.RoleExists("admin"))
            {
                roleManager.Create(new IdentityRole("admin"));
            }

            if (!roleManager.RoleExists("user"))
            {
                roleManager.Create(new IdentityRole("user"));
            }

            var user = new User
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                FirstName = "Admin",
                LastName = "Admin"
            };

            if (userManager.FindByName("admin") == null)
            {
                var result = userManager.Create(user, "admin");
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "admin");
                }
            }
        }
    }
}
