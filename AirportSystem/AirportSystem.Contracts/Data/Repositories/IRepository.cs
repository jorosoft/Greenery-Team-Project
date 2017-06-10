using System.Collections.Generic;

namespace AirportSystem.Contracts.Data.Repositories
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        int Add(T entity);

        void Update(T entity);          
    }
}
