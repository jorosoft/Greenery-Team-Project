using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using AirportSystem.Models.DTO;
using AirportSystem.Contracts.MainDll;
using AirportSystem.Contracts.Models;

namespace AirportSystem.Converters
{
    public class JsonDeserializer : IDeserializer
    {
        public IEnumerable<IFlightDTO> Deserialize(string filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException("No input file name is given!");
            }

            var json = File.ReadAllText(filePath);                       
            var flights = JsonConvert.DeserializeObject<FlightCollection>(json);

            return flights.Flights;
        }
    }
}
