using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AirportSystem.Models.Contracts;

namespace AirportSystem.Models
{
    public class Airport : IAirport
    {    
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(5)]
        [Index(IsUnique = true)]
        public string Code { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(35)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Flight> SourceFlights { get; set; }

        public virtual ICollection<Flight> DestinationFlights { get; set; }
    }
}
