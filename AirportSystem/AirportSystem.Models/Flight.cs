using System;
using System.ComponentModel.DataAnnotations;
using AirportSystem.Models.Contracts;

namespace AirportSystem.Models
{
    public class Flight : IFlight
    {
        public int Id { get; set; }

        [Required]
        public DateTime SheduledDepartureTime { get; set; }

        [Required]
        public DateTime SheduledArrivalTime { get; set; }

        public DateTime ActualDepartureTime { get; set; }

        public DateTime AactualArrivalTime { get; set; }

        [Required]        
        public int SourceAirportId { get; set; }

        [Required]
        public int DestinationAirportId { get; set; }

        [Required]
        public int AircraftId { get; set; }

        public virtual Airport SourceAirport { get; set; }

        public virtual Airport DestinationAirport { get; set; }

        public virtual Aircraft Aircraft { get; set; }
    }
}
