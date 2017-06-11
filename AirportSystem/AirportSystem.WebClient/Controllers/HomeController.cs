using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirportSystem.Contracts.Data;
using AirportSystem.Models.DTO;
using AirportSystem.Data;

namespace AirportSystem.WebClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAirportSystemMsSqlData msSqlData;
        private readonly IAirportSystemPSqlData pSqlData;
        private readonly IAirportSystemSqliteData sqliteData;

        public HomeController(IAirportSystemMsSqlData msSqlData, IAirportSystemPSqlData pSqlData, IAirportSystemSqliteData sqliteData)

        {
            this.msSqlData = msSqlData;
            this.pSqlData = pSqlData;
            this.sqliteData = sqliteData;
        }

        public ActionResult Index()
        {
            var flights = this.msSqlData.Flights.GetAll(null);

            return View(flights);
        }

        [Authorize]
        public ActionResult FlightDetails(int id)
        {
            var flight = msSqlData.Flights.GetAll(x => x.Id == id).FirstOrDefault();

            return View(flight);
        }

        [Authorize]
        public ActionResult EditFlight(int id)
        {
            var flight = msSqlData.Flights.GetAll(x => x.Id == id).FirstOrDefault();

            return View(flight);
        }

        [Authorize]
        public ActionResult DeleteFlight(int id)
        {
            var flight = msSqlData.Flights.GetAll(x => x.Id == id).FirstOrDefault();

            return View(flight);
        }

        [Authorize]
        public ActionResult EditFlightApply()
        {

            Response.AddHeader("REFRESH", "1;URL=Index");
            return View();
        }

        [Authorize]
        public ActionResult DeleteFlightApply()
        {

            Response.AddHeader("REFRESH", "1;URL=Index");
            return View();
        }

        [Authorize]
        public ActionResult Reports()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Greenery Airport System";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contacts";

            ViewBag.AuthorOne = "Zhivko Ivanov";
            ViewBag.GithubOne = "https://github.com/jorosoft";
            ViewBag.AuthorTwo = "Angel Kuzev";
            ViewBag.GithubTwo = "https://github.com/AngelK99";

            return View();
        }
    }
}