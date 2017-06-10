using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using AirportSystem.Contracts.Models;

namespace AirportSystem.Models
{
    public class Terminal : ITerminal
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Airline> Airlines { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
