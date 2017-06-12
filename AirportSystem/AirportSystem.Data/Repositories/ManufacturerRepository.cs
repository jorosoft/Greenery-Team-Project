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
    public class ManufacturerRepository : IRepository<IManufacturer>
    {
        private readonly DbContext context;

        public ManufacturerRepository(DbContext context)
        {
            this.context = context;
        }

        public int Add(IManufacturer entity)
        {
            int id = RepositoryMethods.Add<Manufacturer>(this.context, (Manufacturer)entity, x => x.Name == entity.Name);

            return id;
        }

        public IEnumerable<IManufacturer> GetAll(Expression<Func<IManufacturer, bool>> filter)
        {
            var allEntities = RepositoryMethods.GetAll<Manufacturer>(this.context);

            if (filter != null)
            {
                return allEntities.Where(filter).ToList();

            }
            return allEntities.ToList();
        }

        public void Update(IManufacturer entity)
        {
            RepositoryMethods.Update<Manufacturer>(this.context, (Manufacturer)entity);
        }

        public void Delete(IManufacturer entity)
        {
            throw new NotImplementedException();
        }
    }
}
