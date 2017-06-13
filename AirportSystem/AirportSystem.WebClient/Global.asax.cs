using AirportSystem.Data;
using AirportSystem.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AirportSystem.WebClient
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AirportSystemMsSqlDbContext, ConfigurationMSSql>());
            using (AirportSystemMsSqlDbContext db = new AirportSystemMsSqlDbContext())
            {
                db.Database.CreateIfNotExists();
            }

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<AirportSystemPSqlDbContext, ConfigurationPSql>());
            //using (AirportSystemPSqlDbContext db = new AirportSystemPSqlDbContext())
            //{
            //    db.Database.CreateIfNotExists();
            //}

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<AirportSystemSqliteDbContext, ConfigurationSqlite>());
            //using (AirportSystemSqliteDbContext db = new AirportSystemSqliteDbContext())
            //{
            //    db.Database.CreateIfNotExists();
            //}
        }
    }
}
