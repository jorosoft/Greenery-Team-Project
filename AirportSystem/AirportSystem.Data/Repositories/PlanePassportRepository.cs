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
            return 0;
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

        public void Update(IPlanePassport entity)
        {            
        }

        public void Delete(IPlanePassport entity)
        {
        }
    }
}
