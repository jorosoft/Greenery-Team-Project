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

            var found = context.Set<PlanePassport>().FirstOrDefault(x => x.RegistrationNumber == entity.PlanePass.RegistrationNumber);
            if (found == null)
            {
                var plane = (Plane)entity;
                plane.PlanePassport = (PlanePassport)entity.PlanePass;
                context.Set<Plane>().Add(plane);
                context.SaveChanges();
                id = entity.Id;
            }
            else
            {
                id = found.PlaneId;
            }

            return id;
        }

        public IEnumerable<IPlane> GetAll(Expression<Func<IPlane, bool>> filter)
        {
            var allEntities = RepositoryMethods.GetAll<Plane>(this.context);

            if (filter != null)
            {
                return allEntities.Where(filter).ToList();

            }
            return allEntities.ToList();
        }

        public void Update(IPlane entity)
        {
            RepositoryMethods.Update<Plane>(this.context, (Plane)entity);
        }

        public void Delete(IPlane entity)
        {
            throw new NotImplementedException();
        }
    }
}
