using AirportSystem.Contracts.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
