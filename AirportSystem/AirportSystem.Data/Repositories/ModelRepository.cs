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

        public IEnumerable<IModel> GetAll(Expression<Func<IModel, bool>> filter)
        {
            var allEntities = RepositoryMethods.GetAll<Model>(this.context);

            if (filter != null)
            {
                return allEntities.Where(filter).ToList();

            }
            return allEntities.ToList();
        }

        public void Update(IModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
