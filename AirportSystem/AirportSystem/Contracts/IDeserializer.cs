using System.Collections.Generic;
using AirportSystem.Models.Contracts;

namespace AirportSystem.Contracts
{
    public interface IDeserializer
    {
        IEnumerable<IFlight> Deserialize();
    }
}
