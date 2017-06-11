using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AirportSystem.Contracts.Data.Repositories;
using AirportSystem.Contracts.Models;
using AirportSystem.Data.Repositories.Methods;
using AirportSystem.Models;

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

            if (found == null)
            {
                context.Set<Flight>().Add((Flight)entity);
                context.SaveChanges();
                id = entity.Id;
            }
            else
            {
                id = found.Id;
            }

            return id;
        }

        public IEnumerable<IFlight> GetAll(Expression<Func<IFlight, bool>> filter)
        {
            if (filter != null)
            {
                return this.context.Set<Flight>()
                    .Where(filter)
                    .OrderBy(x => x.SheduledTime)
                    .ToList();
            }

            return this.context.Set<Flight>()
                .OrderBy(x => x.SheduledTime)
                .ToList();            
        }
       
        public void Update(IFlight entity)
        {
            throw new NotImplementedException();
        }
    }
}
