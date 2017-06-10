using System.Data.Entity;

namespace AirportSystem.Data
{
    public class AirportSystemPSqlDbContext : DbContext
    {
        public AirportSystemPSqlDbContext()
            :base("AirportSystemPSql")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
