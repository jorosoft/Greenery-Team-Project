using System.Data.Entity;
using AirportSystem.Models;

namespace AirportSystem.Data
{
    public class AirportSystemDbContext : DbContext
    {
        public AirportSystemDbContext()
            : base("AirportSystemDB")
        {
        }
        
        public virtual IDbSet<Aircraft> Aircrafts { get; set; }

        public virtual IDbSet<Airline> Airlines { get; set; }

        public virtual IDbSet<Airport> Airports { get; set; }

        public virtual IDbSet<Flight> Flights { get; set; }

        public virtual IDbSet<Manufacturer> Manufacturers { get; set; }

        public virtual IDbSet<Model> Models { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                .HasRequired(m => m.SourceAirport)
                .WithMany(m => m.SourceFlights)
                .HasForeignKey(m => m.SourceAirportId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Flight>()
                .HasRequired(m => m.DestinationAirport)
                .WithMany(m => m.DestinationFlights)
                .HasForeignKey(m => m.DestinationAirportId)
                .WillCascadeOnDelete(false);
        }
    }
}
