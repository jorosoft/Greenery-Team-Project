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

        public IEnumerable<IAirline> GetAll()
        {
            return RepositoryMethods.GetAll<Airline>(this.context);
        }

        public IAirline GetById(int id)
        {
            var allElements = RepositoryMethods.GetAll<Airline>(this.context);

            var airline = RepositoryMethods.GetById<Airline>(id, allElements);

            return airline;
        }

        public void Update(IAirline entity)
        {
            throw new NotImplementedException();
        }
    }
}
