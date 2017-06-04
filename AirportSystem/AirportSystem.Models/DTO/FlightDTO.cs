using Newtonsoft.Json;
using System;
using System.Xml.Serialization;
using AirportSystem.Models.Contracts;


namespace AirportSystem.Models.DTO
{
    [Serializable()]
    public class FlightDTO : IFlightDTO
    {
        [XmlElement("sheduledTime")]
        [JsonProperty("sheduledTime")]
        public DateTime SheduledTime { get; set; }

        [XmlElement("airportName")]
        [JsonProperty("airportName")]
        public string DestinationAirportName { get; set; }

        [XmlElement("airportCode")]
        [JsonProperty("airportCode")]
        public string DestinationAirportCode { get; set; }

        [XmlElement("flightType")]
        [JsonProperty("flightType")]
        public string FlightType { get; set; }

        [XmlElement("planeManufacturer")]
        [JsonProperty("planeManufacturer")]
        public string PlaneManufacturer { get; set; }

        [XmlElement("planeModel")]
        [JsonProperty("planeModel")]
        public string PlaneModel { get; set; }

        [XmlElement("planeSeats")]
        [JsonProperty("planeSeats")]
        public int PlaneSeats { get; set; }

        [XmlElement("planeRegistrationNumber")]
        [JsonProperty("planeRegistrationNumber")]
        public string PlaneRegistrationNumber { get; set; }

        [XmlElement("planeYearOfRegistration")]
        [JsonProperty("planeYearOfRegistration")]
        public int PlaneYearOfRegistration { get; set; }

        [XmlElement("planeState")]
        [JsonProperty("planeState")]
        public string PlaneState { get; set; }

        [XmlElement("airline")]
        [JsonProperty("airline")]
        public string Airline { get; set; }

        [XmlElement("terminal")]
        [JsonProperty("terminal")]
        public string Terminal { get; set; }
    }
}
