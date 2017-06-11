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
    public class AirlineRepository : IRepository<IAirline>
    {
        private readonly DbContext context;

        public AirlineRepository(DbContext context)
        {
            this.context = context;
        }

        public int Add(IAirline entity)
        {
            int id = 0;

            var found = context.Set<Airline>().FirstOrDefault(x => x.Name == entity.Name);
            if (found == null)
            {
                context.Set<Airline>().Add((Airline)entity);
                context.SaveChanges();
                id = entity.Id;
            }
            else
            {
                id = found.Id;
            }

            return id;
        }

        public IEnumerable<IAirline> GetAll(Expression<Func<IAirline, bool>> filter)
        {
            if (filter != null)
            {
                return this.context.Set<Airline>().Where(filter).ToList();
            }

            return RepositoryMethods.GetAll<Airline>(this.context);
        }       

        public void Update(IAirline entity)
        {
            throw new NotImplementedException();
        }
    }
}
