using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AirportSystem.Contracts.Models;

namespace AirportSystem.Contracts.Data.Repositories
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter);       

        int Add(T entity);

        void Update(T entity);

        void Delete(T entity);      
    }
}
