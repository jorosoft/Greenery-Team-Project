using System.Collections.Generic;

namespace AirportSystem.Contracts.Data.Repositories
{
    public interface IExtendedRepository<T, K>
        where T : class
        where K : class
    { 

        IEnumerable<T> GetAll();

        T GetById(int id);

        int Add(K entity);

        void Update(T entity);
    }
}
