using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AirportSystem.Models.DTO
{
    public class FlightCollection
    {
        [XmlElement("flight")]
        [JsonProperty("flights")]
        public List<FlightDTO> Flights { get; set; } = new List<FlightDTO>();
    }
}
