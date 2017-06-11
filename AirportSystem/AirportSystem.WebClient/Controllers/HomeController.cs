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