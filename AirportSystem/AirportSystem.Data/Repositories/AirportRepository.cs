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

        public IEnumerable<IAirport> GetAll()
        {
            return RepositoryMethods.GetAll<Airport>(this.context);
        }

        public IAirport GetById(int id)
        {
            var allElements = RepositoryMethods.GetAll<Airport>(this.context);

            var airport = RepositoryMethods.GetById<Airport>(id, allElements);

            return airport;
        }

        public void Update(IAirport entity)
        {
            throw new NotImplementedException();
        }
    }
}
