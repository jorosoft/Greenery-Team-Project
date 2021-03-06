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
    public class AirlineRepository : IRepository<IAirline>
    {
        private readonly DbContext context;

        public AirlineRepository(DbContext context)
        {
            this.context = context;
        }

        public int Add(IAirline entity)
        {
            int id = RepositoryMethods.Add<Airline>(this.context, (Airline)entity, x => x.Name == entity.Name);

            return id;
        }

        public IEnumerable<IAirline> GetAll(Expression<Func<IAirline, bool>> filter)
        {
            var allEntities = RepositoryMethods.GetAll<Airline>(this.context);

            if (filter != null)
            {
                return allEntities.Where(filter).ToList();

            }
            return allEntities.ToList();
        }

        public int Update(IAirline entity)
        {
            var entityToUpdate = this.context
                .Set<Airline>()
                .FirstOrDefault(x => x.Id == entity.Id);

            if (entityToUpdate != null)
            {
                entityToUpdate.Name = entity.Name;
                this.context.SaveChanges();
            }

            return entity.Id;
        }

        public void Delete(IAirline entity)
        {
            RepositoryMethods.Delete<Airline>(this.context, (Airline)entity);
        }
    }
}
