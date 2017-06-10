using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AirportSystem.Contracts.Models;

namespace AirportSystem.Models
{
    public class FlightType : IFlightType
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
