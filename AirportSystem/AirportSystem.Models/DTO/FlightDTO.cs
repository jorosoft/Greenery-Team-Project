using System;
using System.Xml.Serialization;
using AirportSystem.Models.Contracts;

namespace AirportSystem.Models.DTO
{
    [Serializable()]
    public class FlightDTO : IFlightDTO
    {
        [XmlElement("sheduledTime")]
        public DateTime SheduledTime { get; set; }

        [XmlElement("airportName")]
        public string DestinationAirportName { get; set; }

        [XmlElement("airportCode")]
        public string DestinationAirportCode { get; set; }

        [XmlElement("flightType")]
        public string FlightType { get; set; }

        [XmlElement("planeManufacturer")]
        public string PlaneManufacturer { get; set; }

        [XmlElement("planeModel")]
        public string PlaneModel { get; set; }

        [XmlElement("planeSeats")]
        public int PlaneSeats { get; set; }

        [XmlElement("planeRegistrationNumber")]
        public string PlaneRegistrationNumber { get; set; }

        [XmlElement("planeYearOfRegistration")]
        public int PlaneYearOfRegistration { get; set; }

        [XmlElement("planeState")]
        public string PlaneState { get; set; }

        [XmlElement("airline")]
        public string Airline { get; set; }

        [XmlElement("terminal")]
        public string Terminal { get; set; }
    }
}
