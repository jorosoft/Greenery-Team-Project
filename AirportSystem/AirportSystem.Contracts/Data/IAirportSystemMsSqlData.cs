using AirportSystem.Contracts.Data.Repositories;
using AirportSystem.Contracts.Models;

namespace AirportSystem.Contracts.Data
{
    public interface IAirportSystemMsSqlData
    {
        IRepository<IAirport> Airports { get; }

        IRepository<IAirline> Airlines { get; }

        IRepository<IFlight> Flights { get; }

        IRepository<IFlightType> FlightTypes { get; }

        IRepository<IManufacturer> Manufacturers { get; }

        IRepository<IModel> Models { get; }

        IRepository<IPlane> Planes { get; }

        IRepository<IPlanePassport> PlanePassports { get; }

        IRepository<ITerminal> Terminals { get; }
    }
}
