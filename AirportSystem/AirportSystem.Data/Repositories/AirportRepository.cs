using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AirportSystem.Contracts.Data.Repositories;
using AirportSystem.Contracts.Models;
using AirportSystem.Models;

namespace AirportSystem.Data.Repositories
{
    public class AirportRepository : IRepository<IAirport>
    {
        private readonly DbContext context;
        public AirportRepository(DbContext context)
        {
            this.context = context;
        }

        public int Add(IAirport entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAirport> GetAll()
        {
            return this.context.Set<Airport>().ToList();
        }

        public IAirport GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(IAirport entity)
        {
            throw new NotImplementedException();
        }
    }
}
