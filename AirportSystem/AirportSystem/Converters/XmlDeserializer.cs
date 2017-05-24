using System;
using System.Collections.Generic;
using AirportSystem.Contracts;
using AirportSystem.Models.Contracts;

namespace AirportSystem.Converters
{
    public class XmlDeserializer : IDeserializer
    {
        public IEnumerable<IFlight> Deserialize()
        {
            throw new NotImplementedException();
        }
    }
}
