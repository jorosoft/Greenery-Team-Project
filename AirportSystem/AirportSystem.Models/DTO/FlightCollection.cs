using System.Collections.Generic;
using System.Xml.Serialization;

namespace AirportSystem.Models.DTO
{
    public class FlightCollection
    {
        [XmlElement("flight")]
        public List<FlightDTO> Flights { get; set; } = new List<FlightDTO>();
    }
}
