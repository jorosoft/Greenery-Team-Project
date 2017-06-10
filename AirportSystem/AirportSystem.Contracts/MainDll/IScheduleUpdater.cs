using AirportSystem.Contracts.Models;

namespace AirportSystem.Contracts.MainDll
{
    public interface IScheduleUpdater
    {
        void UpdateScheduleFromFile(string filePath, IDeserializer deserializer);

        void AddFlight(IFlight flight);

        void UpdateFlight(int flightId);
    }
}
