using AirportSystem.Contracts.Data;
using System.Data.Entity;

namespace AirportSystem.Data
{
    public class AirportSystemPSqlData : IAirportSystemPSqlData
    {
        private readonly DbContext context;

        public AirportSystemPSqlData(DbContext context)
        {
            this.context = context;
        }
    }
}
