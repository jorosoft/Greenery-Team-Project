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

        public virtual IDbSet<Airport> Airports { get; set; }

        public virtual IDbSet<Flight> Flights { get; set; }
    }
}
