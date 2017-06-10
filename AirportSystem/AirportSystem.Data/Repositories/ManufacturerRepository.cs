using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AirportSystem.Contracts.Data.Repositories;
using AirportSystem.Contracts.Models;
using AirportSystem.Models;
using AirportSystem.Data.Repositories.Methods;

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
            int id = 0;

            var found = context.Set<Manufacturer>().FirstOrDefault(x => x.Name == entity.Name);
            if (found == null)
            {
                context.Set<Manufacturer>().Add((Manufacturer)entity);
                context.SaveChanges();
                id = entity.Id;
            }
            else
            {
                id = found.Id;
            }

            return id;
        }

        public IEnumerable<IManufacturer> GetAll()
        {
            return RepositoryMethods.GetAll<Manufacturer>(this.context);
        }

        public IManufacturer GetById(int id)
        {
            var allElements = RepositoryMethods.GetAll<Manufacturer>(this.context);

            var manufacturer = RepositoryMethods.GetById<Manufacturer>(id, allElements);

            return manufacturer;
        }

        public void Update(IManufacturer entity)
        {
            throw new NotImplementedException();
        }
    }
}
