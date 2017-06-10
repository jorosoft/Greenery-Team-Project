using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AirportSystem.Contracts.Data.Repositories;
using AirportSystem.Contracts.Models;
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

            var found = context.Set<Flight>().FirstOrDefault(x => x.Id == entity.Id);
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

        public IEnumerable<IFlight> GetAll()
        {
            return this.context.Set<Flight>().ToList();
        }

        public IFlight GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(IFlight entity)
        {
            throw new NotImplementedException();
        }
    }
}
