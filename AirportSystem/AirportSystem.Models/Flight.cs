using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using AirportSystem.Models.Contracts;


namespace AirportSystem.Models
{
    [Serializable()]
    public class Flight : IFlight
    {
        public int Id { get; set; }

        [Required]        
        [XmlElement("sheduledTime")]
        public DateTime SheduledTime { get; set; }

        public DateTime? ActualTime { get; set; }              

        [Required]
        public int DestinationAirportId { get; set; }

        [Required]
        public int FlightTypeId { get; set; }

        [Required]
        public int PlaneId { get; set; }

        [XmlElement("destinationAirport")]
        public virtual Airport DestinationAirport { get; set; }

        [XmlElement("flightType")]
        public virtual FlightType FlightType { get; set; }

        [XmlElement("plane")]
        public virtual Plane Plane { get; set; }
    }
}
