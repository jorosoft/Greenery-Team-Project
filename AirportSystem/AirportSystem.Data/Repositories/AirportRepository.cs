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
    public class AirportRepository : IRepository<IAirport>
    {
        private readonly DbContext context;

        public AirportRepository(DbContext context)
        {
            this.context = context;
        }

        public int Add(IAirport entity)
        {
            int id = 0;

            var found = context.Set<Airport>().FirstOrDefault(x => x.Code == entity.Code);
            if (found == null)
            {
                context.Set<Airport>().Add((Airport)entity);
                context.SaveChanges();
                id = entity.Id;
            } 
            else
            {
                id = found.Id;
            }     

            return id;
        }

        public IEnumerable<IAirport> GetAll(Expression<Func<IAirport, bool>> filter)
        {
            var allEntities = RepositoryMethods.GetAll<Airport>(this.context);

            if (filter != null)
            {
                return allEntities.Where(filter).ToList();

            }
            return allEntities.ToList();
        }

        public void Update(IAirport entity)
        {
            throw new NotImplementedException();
        }
    }
}
