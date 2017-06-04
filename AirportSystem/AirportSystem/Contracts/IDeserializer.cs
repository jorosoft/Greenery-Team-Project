using System.Collections.Generic;
using AirportSystem.Models.Contracts;

namespace AirportSystem.Contracts
{
    public interface IDeserializer
    {
        IEnumerable<IFlightDTO> Deserialize(string filePath);
    }
}
