using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AirportSystem.Contracts.Data.Repositories;
using AirportSystem.Contracts.Models;
using AirportSystem.Models;

namespace AirportSystem.Data.Repositories
{
    public class FlightTypeRepository : IRepository<IFlightType>
    {
        private readonly DbContext context;

        public FlightTypeRepository(DbContext context)
        {
            this.context = context;
        }

        public int Add(IFlightType entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IFlightType> GetAll()
        {
            return this.context.Set<FlightType>().ToList();
        }

        public IFlightType GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(IFlightType entity)
        {
            throw new NotImplementedException();
        }
    }
}
