using AirportSystem.Data.Migrations;
using System.Data.Entity;

namespace AirportSystem.Data
{
    public class AirportSystemSqliteDbContext : DbContext
    {
        public AirportSystemSqliteDbContext()
            :base("AirportSystemSqLite")
        {            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
