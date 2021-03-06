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
    public class ModelRepository : IRepository<IModel>
    {
        private readonly DbContext context;

        public ModelRepository(DbContext context)
        {
            this.context = context;
        }

        public int Add(IModel entity)
        {
            int id = RepositoryMethods.Add<Model>(this.context, (Model)entity, x => x.Name == entity.Name);

            return id;
        }

        public IEnumerable<IModel> GetAll(Expression<Func<IModel, bool>> filter)
        {
            var allEntities = RepositoryMethods.GetAll<Model>(this.context);

            if (filter != null)
            {
                return allEntities.Where(filter).ToList();

            }
            return allEntities.ToList();
        }

        public int Update(IModel entity)
        {
            var entityToUpdate = this.context
                .Set<Model>()
                .FirstOrDefault(x => x.Id == entity.Id);

            if (entityToUpdate != null)
            {
                entityToUpdate.Name = entity.Name;
                entityToUpdate.Seats = entity.Seats;
                this.context.SaveChanges();
            }

            return entity.Id;
        }

        public void Delete(IModel entity)
        {
            RepositoryMethods.Delete<Model>(this.context, (Model)entity);
        }
    }
}
