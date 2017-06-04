using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AirportSystem.Models
{
    public class FlightCollection
    {
        [XmlElement("flight")]
        public List<Flight> Flights { get; set; } = new List<Flight>();
    }
}
