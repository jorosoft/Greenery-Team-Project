using AirportSystem.Contracts.Data.Repositories;
using AirportSystem.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AirportSystem.Data.Repositories.Methods
{
    static class RepositoryMethods
    {
        public static int Add<T>(DbContext context, T entity, Expression<Func<T, bool>> filter)
            where T : class, IBaseModel
        {
            int id = 0;

            var found = context.Set<T>().FirstOrDefault(filter);
            if (found == null)
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
                id = entity.Id;
            }
            else
            {
                id = found.Id;
            }

            return id;
        }

        public static IQueryable<T> GetAll<T>(DbContext context)
            where T : class
        {
            return context.Set<T>();
        }        
    }
}
