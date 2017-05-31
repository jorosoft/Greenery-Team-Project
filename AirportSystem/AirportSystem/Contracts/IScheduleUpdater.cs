using AirportSystem.Models.Contracts;

namespace AirportSystem.Contracts
{
    public interface IScheduleUpdater
    {
        void UpdateScheduleFromFile(string filePath, IDeserializer deserializer);

        void AddFlight(IFlight flight);

        void UpdateFlight(int flightId);
    }
}
