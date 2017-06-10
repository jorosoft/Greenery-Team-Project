using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AirportSystem.Contracts.Data.Repositories;
using AirportSystem.Contracts.Models;
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
            throw new NotImplementedException();
        }

        public IEnumerable<ITerminal> GetAll()
        {
            return this.context.Set<Terminal>().ToList();
        }

        public ITerminal GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ITerminal entity)
        {
            throw new NotImplementedException();
        }
    }
}
