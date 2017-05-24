using System;

namespace AirportSystem.Models.Contracts
{
    public interface IFlight
    {
        int Id { get; set; }

        DateTime SheduledDepartureTime { get; set; }

        DateTime SheduledArrivalTime { get; set; }

        DateTime ActualDepartureTime { get; set; }

        DateTime AactualArrivalTime { get; set; }

        int SourceAirportId { get; set; }

        int DestinationAirportId { get; set; }

        int AircraftId { get; set; }
    }
}
