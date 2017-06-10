using System.Data.Entity;
using AirportSystem.Contracts.Data;

namespace AirportSystem.Data
{
    public class AirportSystemSqliteData : IAirportSystemSqliteData
    {
        private readonly DbContext context;

        public AirportSystemSqliteData(DbContext context)
        {
            this.context = context;
        }
    }
}
