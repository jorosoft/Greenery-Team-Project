using System;

namespace AirportSystem.Contracts.Models
{
    public interface IFlight
    {
        int Id { get; set; }

        DateTime SheduledTime { get; set; }

        DateTime? ActualTime { get; set; }

        int FlightTypeId { get; set; }

        int DestinationAirportId { get; set; }

        int PlaneId { get; set; }

        int TerminalId { get; set; }
    }
}
