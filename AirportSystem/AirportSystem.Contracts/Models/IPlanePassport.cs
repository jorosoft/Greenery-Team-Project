using System;

namespace AirportSystem.Contracts.Models
{
    public interface IPlanePassport
    {
        int PlaneId { get; set; }

        string RegistrationNumber { get; set; }

        int YearOfRegistration { get; set; }

        string State { get; set; }
    }
}
