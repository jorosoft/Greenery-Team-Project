using System.Data.Entity;
using AirportSystem.Models;
using AirportSystem.Data.Migrations;

namespace AirportSystem.Data
{
    public class AirportSystemMsSqlDbContext : DbContext
    {
        public AirportSystemMsSqlDbContext()
            : base("AirportSystemDB")
        {            
        }
        
        public virtual IDbSet<Plane> Planes { get; set; }

        public virtual IDbSet<PlanePassport> PlanePassports { get; set; }

        public virtual IDbSet<Airline> Airlines { get; set; }

        public virtual IDbSet<Airport> Airports { get; set; }

        public virtual IDbSet<Flight> Flights { get; set; }

        public virtual IDbSet<FlightType> FlightTypes { get; set; }

        public virtual IDbSet<Manufacturer> Manufacturers { get; set; }

        public virtual IDbSet<Model> Models { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
