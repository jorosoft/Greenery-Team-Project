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
    public class TerminalRepository : IRepository<ITerminal>
    {
        private readonly DbContext context;

        public TerminalRepository(DbContext context)
        {
            this.context = context;
        }

        public int Add(ITerminal entity)
        {
            int id = RepositoryMethods.Add<Terminal>(this.context, (Terminal)entity, x => x.Name == entity.Name);

            return id;
        }

        public IEnumerable<ITerminal> GetAll(Expression<Func<ITerminal, bool>> filter)
        {
            var allEntities = RepositoryMethods.GetAll<Terminal>(this.context);

            if (filter != null)
            {
                return allEntities.Where(filter).ToList();
            }

            return allEntities.ToList();
        }

        public int Update(ITerminal entity)
        {
            var entityToUpdate = this.context
                .Set<Terminal>()
                .FirstOrDefault(x => x.Id == entity.Id);

            if (entityToUpdate != null)
            {
                entityToUpdate.Name = entity.Name;
                this.context.SaveChanges();
            }

            return entity.Id;
        }

        public void Delete(ITerminal entity)
        {
            RepositoryMethods.Delete<Terminal>(this.context, (Terminal)entity);
        }
    }
}
