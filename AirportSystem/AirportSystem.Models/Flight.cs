using System;
using System.ComponentModel.DataAnnotations;
using AirportSystem.Models.Contracts;

namespace AirportSystem.Models
{
    public class Flight : IFlight
    {
        public int Id { get; set; }

        [Required]
        public DateTime SheduledTime { get; set; }

        public DateTime ActualTime { get; set; }              

        [Required]
        public int DestinationAirportId { get; set; }

        [Required]
        public IFlightType FlightTypeId { get; set; }

        [Required]
        public int AircraftId { get; set; }

        public virtual Airport DestinationAirport { get; set; }

        public virtual FlightType FlightType { get; set; }

        public virtual Plane Aircraft { get; set; }
    }
}
