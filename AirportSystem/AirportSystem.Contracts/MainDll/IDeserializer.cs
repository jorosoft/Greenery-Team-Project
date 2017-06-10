using System.Collections.Generic;
using AirportSystem.Contracts.Models;

namespace AirportSystem.Contracts.MainDll
{
    public interface IDeserializer
    {
        IEnumerable<IFlightDTO> Deserialize(string filePath);
    }
}
