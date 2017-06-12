using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirportSystem.Contracts.Data;
using AirportSystem.Models.DTO;
using AirportSystem.Data;
using AirportSystem.Models;
using AirportSystem;
using AirportSystem.Converters;
using AirportSystem.Contracts.MainDll;
using Ninject;
using AirportSystem.Contracts.Models;
using Microsoft.Reporting.WebForms;

namespace AirportSystem.WebClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAirportSystemMsSqlData msSqlData;
        private readonly IAirportSystemPSqlData pSqlData;
        private readonly IAirportSystemSqliteData sqliteData;
        private readonly IScheduleUpdater scheduleUpdater;

        public HomeController(
            IAirportSystemMsSqlData msSqlData,
            IAirportSystemPSqlData pSqlData,
            IAirportSystemSqliteData sqliteData,
            IScheduleUpdater scheduleUpdater)
        {
            this.msSqlData = msSqlData;
            this.pSqlData = pSqlData;
            this.sqliteData = sqliteData;
            this.scheduleUpdater = scheduleUpdater;
        }

        public ActionResult Index(string selected = null)
        {
            int day = 0;
            int month = 0;
            int year = 0;
            string selectedDate;

            if (selected != null)
            {
                string[] date = selected.Split('-');
                day = int.Parse(date[0]);
                month = int.Parse(date[1]);
                year = int.Parse(date[2]);
                selectedDate = selected;
            }
            else
            {
                day = DateTime.Now.Day;
                month = DateTime.Now.Month;
                year = DateTime.Now.Year;
                selectedDate = $"{day}-{month}-{year}";
            }

            var flights = this.msSqlData.Flights
                .GetAll(x => x.SheduledTime.Day == day &&
                            x.SheduledTime.Month == month &&
                            x.SheduledTime.Year == year);

            var result = new List<Flight>();

            foreach (var flight in flights)
            {
                result.Add((Flight)flight);
            }

            ViewBag.selected = selectedDate;

            return View(result);
        }

        [Authorize]
        public ActionResult FlightDetails(int id)
        {
            var flight = this.msSqlData.Flights.GetAll(x => x.Id == id).FirstOrDefault();

            return View(flight);
        }

        [Authorize]
        public ActionResult AddFlight()
        {
            ViewBag.FlightTypes = this.msSqlData.FlightTypes.GetAll(null);

            return View();
        }

        [Authorize]
        public ActionResult AddFlightApply(Flight flight)
        {
            this.scheduleUpdater.AddFlight(flight);

            Response.AddHeader("REFRESH", "1;URL=Index");

            return View();
        }

        [Authorize]
        public ActionResult EditFlight(int id)
        {
            var flight = this.msSqlData.Flights.GetAll(x => x.Id == id).FirstOrDefault();

            return View(flight);
        }

        [Authorize]
        public ActionResult EditFlightApply(Flight flight)
        {
            this.scheduleUpdater.UpdateFlight(flight);

            Response.AddHeader("REFRESH", "1;URL=Index");

            return View();
        }

        [Authorize]
        public ActionResult DeleteFlight(int id)
        {
            var flight = msSqlData.Flights.GetAll(x => x.Id == id).FirstOrDefault();

            return View(flight);
        }

        [Authorize]
        public ActionResult DeleteFlightApply(Flight flight)
        {
            this.msSqlData.Flights.Delete(flight);

            Response.AddHeader("REFRESH", "1;URL=Index");

            return View();
        }

        [Authorize]
        public ActionResult UploadFlights()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult UploadFlightsApply()
        {
            const string xmlContentType = "text/xml";
            const string jsonContentType = "application/octet-stream";
            const string excelContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                var fileName = Path.GetFileName(file.FileName);
                var fileExtension = Path.GetExtension(file.FileName);

                if (file != null && file.ContentLength > 0)
                {
                    bool isSupportedFile = (file.ContentType == xmlContentType && fileExtension.ToLower() == ".xml") ||
                                        (file.ContentType == jsonContentType && fileExtension.ToLower() == ".json") ||
                                        (file.ContentType == excelContentType && fileExtension.ToLower() == ".xlsx");

                    if (!isSupportedFile)
                    {
                        return RedirectToAction("Error", new { message = "Not supported file type!" });
                    }

                    var path = Path.Combine(Server.MapPath("~/App_Data/"), fileName);
                    file.SaveAs(path);

                    switch (file.ContentType)
                    {
                        case xmlContentType:
                            this.scheduleUpdater.UpdateScheduleFromFile(path, new XmlDeserializer());
                            break;
                        case jsonContentType:
                            this.scheduleUpdater.UpdateScheduleFromFile(path, new JsonDeserializer());
                            break;
                        case excelContentType:
                            this.scheduleUpdater.UpdateScheduleFromFile(path, new ExcelDeserializer());
                            break;
                        default:
                            break;
                    }
                }
            }

            Response.AddHeader("REFRESH", "1;URL=Index");

            return View();
        }

        [Authorize]
        public ActionResult Reports()
        {
            return View();
        }

        [Authorize]
        public ActionResult ReportGenerator(dynamic model, string dataset, string file)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Reports"), file);
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Index");
            }

            ReportDataSource rd = new ReportDataSource(dataset, model);
            lr.DataSources.Add(rd);

            string reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;
            string deviceInfo =
            "<DeviceInfo>" +
            "  <OutputFormat>" + "PDF" + "</OutputFormat>" +
            "  <PageWidth>8.5in</PageWidth>" +
            "  <PageHeight>11in</PageHeight>" +
            "  <MarginTop>0.5in</MarginTop>" +
            "  <MarginLeft>0.5in</MarginLeft>" +
            "  <MarginRight>0.5in</MarginRight>" +
            "  <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);

            return File(renderedBytes, mimeType);
        }

        [Authorize]
        public ActionResult ReportAirlines()
        {
            var airlines = this.msSqlData.Airlines.GetAll(null);
            var data = "AirlinesDataSet";
            var file = "AirlinesReport.rdlc";

            return ReportGenerator(airlines, data, file);
        }

        public ActionResult Error(string message)
        {
            ViewBag.message = message;

            Response.AddHeader("REFRESH", "1;URL=Index");

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