using System;
using System.Data.Entity;
using AirportSystem.Converters;
using AirportSystem.Data;
using AirportSystem.Data.Migrations;
using AirportSystem.Models;
using AirportSystem.Data.Repositories;
using System.Linq;

namespace AirportSystem.ConsoleClient
{
    // Just for test purposes at development
    internal class Startup
    {
        internal static void Main()
        {
            // Test connection to SQL Server
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AirportSystemMsSqlDbContext, ConfigurationMSSql>());
            using (AirportSystemMsSqlDbContext db = new AirportSystemMsSqlDbContext())
            {
                db.Database.CreateIfNotExists();

                foreach (var e in db.FlightTypes)
                {
                    Console.WriteLine(e.Name);
                }
            }

            // Test Deserializers
            var xmlSer = new XmlDeserializer();
            var jsonSer = new JsonDeserializer();
            var excelSer = new ExcelDeserializer();

            var xmlPath = "../../../SampleInputFiles/sample.xml";
            var jsonPath = "../../../SampleInputFiles/sample.json";
            var excelPath = "../../../SampleInputFiles/sample.xlsx";
                        

            // Test repository

            var msSqlData = new AirportSystemMsSqlData(new AirportSystemMsSqlDbContext());
            var pSqlData = new AirportSystemPSqlData(new AirportSystemPSqlDbContext());
            var sqliteData = new AirportSystemSqliteData(new AirportSystemSqliteDbContext());

            msSqlData.Airports.Add(new Airport
            {
                Code = "LBWN",
                Name = "Varna Airport"
            });

            msSqlData.Airports.Add(new Airport
            {
                Code = "LBSF",
                Name = "Sofia Airport"
            });

            msSqlData.Airlines.Add(new Airline
            {
                Name = "Bongo Air"
            });

            Console.WriteLine();
            Console.WriteLine("Airports:");
            Console.WriteLine("==========");
            
            foreach (var entity in msSqlData.Airports.GetAll(null))
            {
                Console.WriteLine("{0} - {1}", entity.Code, entity.Name);
            }

            Console.WriteLine("Airlines:");
            Console.WriteLine("==========");
            foreach (var entity in msSqlData.Airlines.GetAll(null))
            {
                Console.WriteLine("{0}", entity.Name);
            }

            // Test shedule updater
            var su = new ScheduleUpdater(msSqlData, pSqlData, sqliteData);
            int countAdded = 0;
            countAdded = su.UpdateScheduleFromFile(xmlPath, xmlSer);
            Console.WriteLine("{0} FLIGHTS ADDDED!!!", countAdded);
            countAdded = su.UpdateScheduleFromFile(jsonPath, jsonSer);
            Console.WriteLine("{0} FLIGHTS ADDDED!!!", countAdded);
            countAdded = su.UpdateScheduleFromFile(excelPath, excelSer);
            Console.WriteLine("{0} FLIGHTS ADDDED!!!", countAdded);
            Console.WriteLine();

            var f = new FlightRepository(new AirportSystemMsSqlDbContext());
            var allFlights = f.GetAll(null);

            foreach (var item in allFlights)
            {
                var fl = (Flight)item;
                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6} - {7} - {8} - {9} - {10} - {11}", 
                    fl.DestinationAirport.Name,
                    fl.DestinationAirport.Code,
                    fl.FlightType.Name,
                    fl.Plane.Manufacturers.Name,
                    fl.Terminal.Name,
                    fl.Plane.Airlines.Name,
                    fl.Plane.PlanePassport.RegistrationNumber,
                    fl.Plane.PlanePassport.YearOfRegistration,
                    fl.Plane.PlanePassport.State,
                    fl.SheduledTime,
                    fl.Plane.Models.Name,
                    fl.Plane.Models.Seats);
            }

            var filteredFlights = f.GetAll(x => x.DestinationAirportId == 3);
            Console.WriteLine(filteredFlights.Count());
        }
    }
}
