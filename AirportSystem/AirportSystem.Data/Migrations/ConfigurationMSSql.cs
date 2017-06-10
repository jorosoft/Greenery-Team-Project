namespace AirportSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    public sealed class ConfigurationMSSql : DbMigrationsConfiguration<AirportSystemMsSqlDbContext>
    {
        public ConfigurationMSSql()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AirportSystem.Data.AirportSystemMsSqlDbContext context)
        {
            ////  This method will be called after migrating to the latest version.

            context.FlightTypes.AddOrUpdate(
                f => f.Name,
                new FlightType { Name = "Arrivals" },
                new FlightType { Name = "Departures" });
        }
    }
}
