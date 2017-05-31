using System;
using System.Collections.Generic;
using AirportSystem.Contracts;
using AirportSystem.Models.Contracts;
using AirportSystem.Data.Contracts;

namespace AirportSystem
{
    public class ScheduleUpdater : IScheduleUpdater
    {
        private readonly IRepository repository;

        public ScheduleUpdater(IRepository repository)
        {            
            this.repository = repository;
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
