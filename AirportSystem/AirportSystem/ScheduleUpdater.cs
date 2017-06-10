using System;
using AirportSystem.Contracts.Data;
using AirportSystem.Contracts.Data.Repositories;
using AirportSystem.Contracts.MainDll;
using AirportSystem.Contracts.Models;


namespace AirportSystem
{
    public class ScheduleUpdater : IScheduleUpdater
    {
        private readonly IAirportSystemMsSqlData msSqlData;

        public ScheduleUpdater(IAirportSystemMsSqlData msSqlData)
        {
            this.msSqlData = msSqlData;
        }

        public void UpdateScheduleFromFile(string filePath, IDeserializer deserializer)
        {
            var flights = deserializer.Deserialize(filePath);

            throw new NotImplementedException();
        }

        public void AddFlight(IFlight flight)
        {
            throw new NotImplementedException();
        }

        public void UpdateFlight(int flightId)
        {
            throw new NotImplementedException();
        }
    }
}
