using System;
using System.Data.Entity;
using AirportSystem.Data;
using AirportSystem.Data.Migrations;

namespace AirportSystem.ConsoleClient
{
    // Just for test purposes at development
    internal class Startup
    {
        internal static void Main()
        {
            // Test connection to SQL Server
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AirportSystemDbContext, Configuration>());
            using (AirportSystemDbContext db = new AirportSystemDbContext())
            {
                db.Database.CreateIfNotExists();

                foreach (var e in db.FlightTypes)
                {
                    Console.WriteLine(e.Name);
                }
            }
        }
    }
}
