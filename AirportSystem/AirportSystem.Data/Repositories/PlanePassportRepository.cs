using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AirportSystem.Contracts.Data.Repositories;
using AirportSystem.Contracts.Models;
using AirportSystem.Models;

namespace AirportSystem.Data.Repositories
{
    public class PlanePassportRepository : IRepository<IPlanePassport>
    {
        private readonly DbContext context;

        public PlanePassportRepository(DbContext context)
        {
            this.context = context;
        }

        public int Add(IPlanePassport entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPlanePassport> GetAll()
        {
            return this.context.Set<PlanePassport>().ToList();
        }

        public IPlanePassport GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(IPlanePassport entity)
        {
            throw new NotImplementedException();
        }
    }
}
