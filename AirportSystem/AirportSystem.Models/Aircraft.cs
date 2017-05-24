using System.Collections.Generic;
using AirportSystem.Models.Contracts;

namespace AirportSystem.Models
{
    public class Aircraft : IAircraft
    {
        public int Id { get; set; }

        public int ManufacturerId { get; set; }

        public int ModelId { get; set; }

        public int OwnerAirlineId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public virtual Model Models { get; set; }

        public virtual Airline Airlines { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
