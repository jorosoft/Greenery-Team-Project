using AirportSystem.Contracts.Models;

namespace AirportSystem.Contracts.MainDll
{
    public interface IScheduleUpdater
    {
        int UpdateScheduleFromFile(string filePath, IDeserializer deserializer);

        void AddFlight(IFlight flight);

        void UpdateFlight(IFlight flight);
    }
}
