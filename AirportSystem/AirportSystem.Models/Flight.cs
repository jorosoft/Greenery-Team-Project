using System;
using System.ComponentModel.DataAnnotations;
using AirportSystem.Contracts.Models;

namespace AirportSystem.Models
{
    public class Flight : IFlight, IBaseModel
    {
        public int Id { get; set; }

        [Required]        
        public DateTime SheduledTime { get; set; }

        public DateTime? ActualTime { get; set; }              

        [Required]
        public int DestinationAirportId { get; set; }

        [Required]
        public int FlightTypeId { get; set; }

        [Required]
        public int PlaneId { get; set; }

        [Required]
        public int TerminalId { get; set; }

        public virtual Airport DestinationAirport { get; set; }

        public virtual FlightType FlightType { get; set; }

        public virtual Plane Plane { get; set; }

        public virtual Terminal Terminal { get; set; }
    }
}
