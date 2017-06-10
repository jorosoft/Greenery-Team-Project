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
    public class TerminalRepository : IRepository<ITerminal>
    {
        private readonly DbContext context;

        public TerminalRepository(DbContext context)
        {
            this.context = context;
        }

        public int Add(ITerminal entity)
        {
            int id = 0;

            var found = context.Set<Terminal>().FirstOrDefault(x => x.Name == entity.Name);
            if (found == null)
            {
                context.Set<Terminal>().Add((Terminal)entity);
                context.SaveChanges();
                id = entity.Id;
            }
            else
            {
                id = found.Id;
            }

            return id;
        }

        public IEnumerable<ITerminal> GetAll()
        {
            return RepositoryMethods.GetAll<Terminal>(this.context);
        }

        public ITerminal GetById(int id)
        {
            var allElements = RepositoryMethods.GetAll<Terminal>(this.context);

            var terminal = RepositoryMethods.GetById<Terminal>(id, allElements);

            return terminal;
        }

        public void Update(ITerminal entity)
        {
            throw new NotImplementedException();
        }
    }
}
