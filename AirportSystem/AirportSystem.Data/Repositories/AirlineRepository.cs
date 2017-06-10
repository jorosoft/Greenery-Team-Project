using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AirportSystem.Contracts.Data.Repositories;
using AirportSystem.Contracts.Models;
using AirportSystem.Models;

namespace AirportSystem.Data.Repositories
{
    public class AirlineRepository : IRepository<IAirline>
    {
        private readonly DbContext context;

        public AirlineRepository(DbContext context)
        {
            this.context = context;
        }

        public int Add(IAirline entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAirline> GetAll()
        {
            return this.context.Set<Airline>().ToList();
        }

        public IAirline GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(IAirline entity)
        {
            throw new NotImplementedException();
        }
    }
}
