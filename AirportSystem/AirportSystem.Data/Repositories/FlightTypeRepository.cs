﻿using System;
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

        public IEnumerable<IFlightType> GetAll(Expression<Func<IFlightType, bool>> filter)
        {
            if (filter != null)
            {
                return this.context.Set<FlightType>().Where(filter).ToList();

            }
            return RepositoryMethods.GetAll<FlightType>(this.context);
        }
        
        public void Update(IFlightType entity)
        {
            throw new NotImplementedException();
        }
    }
}
