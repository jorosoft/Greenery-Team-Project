using System;

namespace AirportSystem.Models.Contracts
{
    public interface IFlight
    {
        int Id { get; set; }

        DateTime SheduledTime { get; set; }

        DateTime ActualTime { get; set; }

        IFlightType FlightTypeId { get; set; }

        int DestinationAirportId { get; set; }

        int AircraftId { get; set; }
    }
}
