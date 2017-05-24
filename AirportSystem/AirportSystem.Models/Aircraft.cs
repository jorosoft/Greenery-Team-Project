using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AirportSystem.Models.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportSystem.Models
{
    [Table("Aircrafts")]
    public class Aircraft : IAircraft
    {
        public int Id { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        public int ModelId { get; set; }

        [Required]
        public int AirlineId { get; set; }

        public virtual Manufacturer Manufacturers { get; set; }

        public virtual Model Models { get; set; }

        public virtual Airline Airlines { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
