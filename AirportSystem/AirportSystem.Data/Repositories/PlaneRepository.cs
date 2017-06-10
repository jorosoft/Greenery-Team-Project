using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AirportSystem.Contracts.Data.Repositories;
using AirportSystem.Contracts.Models;
using AirportSystem.Models;

namespace AirportSystem.Data.Repositories
{
    public class PlaneRepository : IRepository<IPlane>
    {
        private readonly DbContext context;

        public PlaneRepository(DbContext context)
        {
            this.context = context;
        }

        public int Add(IPlane entity)
        {
            int id = 0;

            var found = context.Set<Plane>().FirstOrDefault(x => x.Id == entity.Id);
            if (found == null)
            {
                context.Set<Plane>().Add((Plane)entity);
                context.SaveChanges();
                id = entity.Id;
            }
            else
            {
                id = found.Id;
            }

            return id;
        }

        public IEnumerable<IPlane> GetAll()
        {
            return this.context.Set<Plane>().ToList();
        }

        public IPlane GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(IPlane entity)
        {
            throw new NotImplementedException();
        }
    }
}
