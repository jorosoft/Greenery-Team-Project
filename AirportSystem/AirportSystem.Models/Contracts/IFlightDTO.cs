using System;

namespace AirportSystem.Models.Contracts
{
    public interface IFlightDTO
    {
        DateTime SheduledTime { get; set; }

        string DestinationAirportName { get; set; }

        string DestinationAirportCode { get; set; }

        string FlightType { get; set; }

        string PlaneManufacturer { get; set; }

        string PlaneModel { get; set; }

        int PlaneSeats { get; set; }

        string PlaneRegistrationNumber { get; set; }

        int PlaneYearOfRegistration { get; set; }

        string PlaneState { get; set; }

        string Airline { get; set; }

        string Terminal { get; set; }
    }
}
