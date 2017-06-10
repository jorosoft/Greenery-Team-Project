using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AirportSystem.Contracts.Data.Repositories;
using AirportSystem.Contracts.Models;
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
            throw new NotImplementedException();
        }

        public IEnumerable<IModel> GetAll()
        {
            return this.context.Set<Model>().ToList();
        }

        public IModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(IModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
