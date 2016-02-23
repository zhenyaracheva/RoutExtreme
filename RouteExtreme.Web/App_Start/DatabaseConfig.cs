namespace RouteExtreme.Web.App_Start
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RouteExtremeDbContext, Configuration>());
            RouteExtremeDbContext.Create().Database.Initialize(true);
            Seed(new RouteExtremeDbContext());
        }

        private static void Seed(IRouteExtremeDbContext db)
        {
        }
    }
}