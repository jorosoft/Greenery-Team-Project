using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirportSystem.Models.DTO;

namespace AirportSystem.WebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var flights = new List<FlightDTO>()
            {
                new FlightDTO()
                {
                SheduledTime = new DateTime(2017, 06, 11, 20, 15, 00),
                FlightType = "Arrivals",
                DestinationAirportCode = "LBPD",
                DestinationAirportName = "Plovdiv Airport",
                Airline = "Bulgaria Air",
                PlaneManufacturer = "Boeing",
                PlaneModel = "747"
                },
                new FlightDTO()
                {
                SheduledTime = new DateTime(2017, 06, 13, 22, 45, 00),
                FlightType = "Arrivals",
                DestinationAirportCode = "LBSF",
                DestinationAirportName = "Sofia Airport",
                Airline = "Colombia Air",
                PlaneManufacturer = "Airbus",
                PlaneModel = "A320"
                },
                new FlightDTO()
                {
                SheduledTime = new DateTime(2017, 06, 12, 12, 00, 00),
                FlightType = "Departures",
                DestinationAirportCode = "LBWN",
                DestinationAirportName = "Varna Airport",
                Airline = "Hemus Air",
                PlaneManufacturer = "Boeing",
                PlaneModel = "777"
                }
            };

            return View(flights);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}