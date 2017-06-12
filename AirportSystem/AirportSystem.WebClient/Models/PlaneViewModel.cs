using AirportSystem.Contracts.Models;
using AirportSystem.Models;

namespace AirportSystem.WebClient.Models
{
    public class PlaneViewModel
    {
        public PlaneViewModel(Plane plane)
        {
            this.PlaneManufacturer = plane.Manufacturers.Name;
            this.PlaneModel = plane.Models.Name;
            this.PlaneSeats = plane.Models.Seats;
            this.PlaneRegNumber = plane.PlanePassport.RegistrationNumber;
            this.PlaneYearOfReg = plane.PlanePassport.YearOfRegistration;
            this.PlaneState = plane.PlanePassport.State;
        }

        public string PlaneManufacturer { get; set; }

        public string PlaneModel { get; set; }

        public string PlaneRegNumber { get; set; }

        public int PlaneYearOfReg { get; set; }

        public int PlaneSeats { get; set; }

        public string PlaneState { get; set; }
    }
}