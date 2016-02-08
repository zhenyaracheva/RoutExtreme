namespace BulBike.Web.App_Start
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BulBikeDbContext, Configuration>());
            BulBikeDbContext.Create().Database.Initialize(true);
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<TriviaMagDbContext, Configuration>(true));
            Seed(new BulBikeDbContext());
        }

        private static void Seed(IBulBikeDbContext db)
        {
            //var userManager = new UserManager<User>(new UserStore<User>(db));
            //if (db.Users.Select(x => x.Firstname == "Test").ToList().Count() == 0)
            //{
            //    // Users
            //    var admin = new User()
            //    {
            //        Firstname = "Admin",
            //        Lastname = "Admin",
            //        Email = "admin@gmail.com",
            //        Role = "Admin",
            //        UserName = "admin"
            //    };
            //    userManager.Create(admin, "123456");

            //}
        }
    }
}