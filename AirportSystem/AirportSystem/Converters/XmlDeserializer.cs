using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using AirportSystem.Contracts.MainDll;
using AirportSystem.Contracts.Models;
using AirportSystem.Models.DTO;

namespace AirportSystem.Converters
{
    public class XmlDeserializer : IDeserializer
    {
        public IEnumerable<IFlightDTO> Deserialize(string filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException("No input file name is given!");
            }
            
            var serializer = new XmlSerializer(typeof(FlightCollection), new XmlRootAttribute("flights"));
            var reader = new StreamReader(filePath);
            var result = (FlightCollection)serializer.Deserialize(reader);
            reader.Close();

            return result.Flights;
        }
    }
}
