using System;

namespace AirportSystem.Models.Contracts
{
    public interface IPlanePassport
    {
        int PlaneId { get; set; }

        string RegistrationNumber { get; set; }

        int YearOfRegistration { get; set; }

        string State { get; set; }
    }
}
