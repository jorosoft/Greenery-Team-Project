using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AirportSystem.Contracts.Data.Repositories;
using AirportSystem.Contracts.Models;
using AirportSystem.Models;

namespace AirportSystem.Data.Repositories
{
    public class FlightTypeRepository : IRepository<IFlightType>
    {
        private readonly DbContext context;

        public FlightTypeRepository(DbContext context)
        {
            this.context = context;
        }

        public int Add(IFlightType entity)
        {
            int id = 0;

            var found = context.Set<FlightType>().FirstOrDefault(x => x.Name == entity.Name);
            if (found == null)
            {
                context.Set<FlightType>().Add((FlightType)entity);
                context.SaveChanges();
                id = entity.Id;
            }
            else
            {
                id = found.Id;
            }

            return id;
        }

        public IEnumerable<IFlightType> GetAll()
        {
            return this.context.Set<FlightType>().ToList();
        }

        public IFlightType GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(IFlightType entity)
        {
            throw new NotImplementedException();
        }
    }
}
