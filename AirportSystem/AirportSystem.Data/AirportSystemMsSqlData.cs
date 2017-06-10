using System.Data.Entity;
using AirportSystem.Contracts.Data;
using AirportSystem.Contracts.Data.Repositories;
using AirportSystem.Contracts.Models;
using AirportSystem.Data.Repositories;


namespace AirportSystem.Data
{
    public class AirportSystemMsSqlData : IAirportSystemMsSqlData
    {
        private readonly DbContext context;

        public AirportSystemMsSqlData(DbContext context)
        {
            this.context = context;
        }

        public IRepository<IAirport> Airports => new AirportRepository(context);

        public IRepository<IAirline> Airlines => new AirlineRepository(context);

        public IRepository<IFlight> Flights => new FlightRepository(context);

        public IRepository<IManufacturer> Manufacturers => new ManufacturerRepository(context);

        public IRepository<IModel> Models => new ModelRepository(context);

        public IRepository<IPlane> Planes => new PlaneRepository(context);

        public IRepository<IPlanePassport> PlanePassports=> new PlanePassportRepository(context);

        public IRepository<ITerminal> Terminals => new TerminalRepository(context);
    }
}
