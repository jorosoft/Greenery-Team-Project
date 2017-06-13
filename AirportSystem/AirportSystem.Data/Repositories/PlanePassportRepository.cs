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
    public class PlanePassportRepository : IRepository<IPlanePassport>
    {
        private readonly DbContext context;

        public PlanePassportRepository(DbContext context)
        {
            this.context = context;
        }

        public int Add(IPlanePassport entity)
        {
            return entity.PlaneId;
        }        

        public IEnumerable<IPlanePassport> GetAll(Expression<Func<IPlanePassport, bool>> filter)
        {
            var allEntities = RepositoryMethods.GetAll<PlanePassport>(this.context);

            if (filter != null)
            {
                return allEntities.Where(filter).ToList();
            }

            return allEntities.ToList();
        }

        public int Update(IPlanePassport entity)
        {
            var entityToUpdate = this.context
                .Set<PlanePassport>()
                .FirstOrDefault(x => x.PlaneId == entity.PlaneId);

            if (entityToUpdate != null)
            {
                entityToUpdate.RegistrationNumber = entity.RegistrationNumber;
                entityToUpdate.YearOfRegistration = entity.YearOfRegistration;
                entityToUpdate.State = entity.State;

                this.context.SaveChanges();
            }

            return entity.PlaneId;
        }

        public void Delete(IPlanePassport entity)
        {
            RepositoryMethods.Delete<PlanePassport>(this.context, (PlanePassport)entity);
        }
    }
}
