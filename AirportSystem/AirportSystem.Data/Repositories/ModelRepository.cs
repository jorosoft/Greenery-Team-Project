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
    public class ModelRepository : IRepository<IModel>
    {
        private readonly DbContext context;

        public ModelRepository(DbContext context)
        {
            this.context = context;
        }

        public int Add(IModel entity)
        {
            int id = 0;

            var found = context.Set<Model>().FirstOrDefault(x => x.Name == entity.Name);
            if (found == null)
            {
                context.Set<Model>().Add((Model)entity);
                context.SaveChanges();
                id = entity.Id;
            }
            else
            {
                id = found.Id;
            }

            return id;
        }

        public IEnumerable<IModel> GetAll()
        {
            return RepositoryMethods.GetAll<Model>(this.context);
        }

        public IModel GetById(int id)
        {
            var allElements = RepositoryMethods.GetAll<Model>(this.context);

            var model = RepositoryMethods.GetById<Model>(id, allElements);

            return model;
        }

        public void Update(IModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
