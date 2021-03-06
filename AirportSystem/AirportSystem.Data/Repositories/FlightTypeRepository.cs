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
            int id = RepositoryMethods.Add<FlightType>(this.context, (FlightType)entity, x => x.Name == entity.Name);

            return id;
        }

        public IEnumerable<IFlightType> GetAll(Expression<Func<IFlightType, bool>> filter)
        {
            var allEntities = RepositoryMethods.GetAll<FlightType>(this.context); 

            if (filter != null)
            {
                return allEntities.Where(filter).ToList();

            }
            return allEntities.ToList();
        }
        
        public int Update(IFlightType entity)
        {
            var entityToUpdate = this.context
                .Set<FlightType>()
                .FirstOrDefault(x => x.Id == entity.Id);

            if (entityToUpdate != null)
            {
                entityToUpdate.Name = entity.Name;
                this.context.SaveChanges();
            }

            return entity.Id;
        }

        public void Delete(IFlightType entity)
        {
            RepositoryMethods.Delete<FlightType>(this.context, (FlightType)entity);
        }
    }
}
