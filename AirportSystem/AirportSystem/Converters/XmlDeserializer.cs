using System;
using System.Collections.Generic;
using AirportSystem.Contracts;
using AirportSystem.Models.Contracts;

namespace AirportSystem.Converters
{
    public class XmlDeserializer : IDeserializer
    {
        public IEnumerable<IFlight> Deserialize(string filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException("No input file name is given!");
            }

            throw new NotImplementedException();
        }
    }
}
