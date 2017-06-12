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
            int id = RepositoryMethods.Add<Flight>(this.context,
                                                   (Flight)entity,
                                                   x => DbFunctions.DiffYears(x.SheduledTime, entity.SheduledTime) == 0 &&
                                                        DbFunctions.DiffMonths(x.SheduledTime, entity.SheduledTime) == 0 &&
                                                        DbFunctions.DiffDays(x.SheduledTime, entity.SheduledTime) == 0 &&
                                                        DbFunctions.DiffHours(x.SheduledTime, entity.SheduledTime) == 0 &&
                                                        DbFunctions.DiffMinutes(x.SheduledTime, entity.SheduledTime) == 0 &&
                                                        x.DestinationAirportId == entity.DestinationAirportId &&
                                                        x.FlightTypeId == entity.FlightTypeId);

            return id;
        }

        public IEnumerable<IFlight> GetAll(Expression<Func<IFlight, bool>> filter)
        {
            var allEntities = RepositoryMethods.GetAll<Flight>(this.context);

            if (filter != null)
            {
                return allEntities.Where(filter).ToList();

            }
            return allEntities.ToList();
        }
       
        public void Update(IFlight entity)
        {
            RepositoryMethods.Update<Flight>(this.context, (Flight)entity);
        }

        public void Delete(IFlight entity)
        {
            throw new NotImplementedException();
        }
    }
}
