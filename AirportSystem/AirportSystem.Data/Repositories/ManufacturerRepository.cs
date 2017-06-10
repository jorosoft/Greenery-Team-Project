using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AirportSystem.Contracts.Data.Repositories;
using AirportSystem.Contracts.Models;
using AirportSystem.Models;

namespace AirportSystem.Data.Repositories
{
    public class ManufacturerRepository : IRepository<IManufacturer>
    {
        private readonly DbContext context;

        public ManufacturerRepository(DbContext context)
        {
            this.context = context;
        }

        public int Add(IManufacturer entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IManufacturer> GetAll()
        {
            return this.context.Set<Manufacturer>().ToList();
        }

        public IManufacturer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(IManufacturer entity)
        {
            throw new NotImplementedException();
        }
    }
}
