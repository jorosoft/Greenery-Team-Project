﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AirportSystem.Contracts.Data.Repositories;
using AirportSystem.Contracts.Models;
using AirportSystem.Models;
using AirportSystem.Data.Repositories.Methods;

namespace AirportSystem.Data.Repositories
{
    public class FlightRepository : IRepository<IFlight>
    {
        private readonly DbContext context;

        public FlightRepository(DbContext context)
        {
            this.context = context;
        }

        public int Add(IFlight entity)
        {
            int id = 0;

            var found = context.Set<Flight>().FirstOrDefault(
                 x => DbFunctions.DiffYears(x.SheduledTime, entity.SheduledTime) == 0 &&
                     DbFunctions.DiffMonths(x.SheduledTime, entity.SheduledTime) == 0 &&
                     DbFunctions.DiffDays(x.SheduledTime, entity.SheduledTime) == 0 &&
                     DbFunctions.DiffHours(x.SheduledTime, entity.SheduledTime) == 0 &&
                     DbFunctions.DiffMinutes(x.SheduledTime, entity.SheduledTime) == 0 &&
                     x.DestinationAirportId == entity.DestinationAirportId &&
                     x.FlightTypeId == entity.FlightTypeId);

            return id;
        }

        public IEnumerable<IFlight> GetAll()
        {
            return RepositoryMethods.GetAll<Flight>(this.context);
        }

        public IFlight GetById(int id)
        {
            var allElements = RepositoryMethods.GetAll<Flight>(this.context);

            var flight = RepositoryMethods.GetById<Flight>(id, allElements);

            return flight;
        }

        public void Update(IFlight entity)
        {
            throw new NotImplementedException();
        }
    }
}
