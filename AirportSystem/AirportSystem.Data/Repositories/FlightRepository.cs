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
            throw new NotImplementedException();
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
