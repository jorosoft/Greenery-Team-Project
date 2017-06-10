using System;
using System.Data.Entity;
using AirportSystem.Converters;
using AirportSystem.Data;
using AirportSystem.Data.Migrations;
using AirportSystem.Models;

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

            // var flights = xmlSer.Deserialize("../../../SampleInputFiles/sample.xml");
            // var flights = jsonSer.Deserialize("../../../SampleInputFiles/sample.json");
            var flights = excelSer.Deserialize("../../../SampleInputFiles/sample.xlsx");

            foreach (var flight in flights)
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6} - {7} - {8} - {9} - {10} - {11}", 
                    flight.SheduledTime,
                    flight.DestinationAirportCode,
                    flight.DestinationAirportName,
                    flight.Airline,
                    flight.FlightType,
                    flight.PlaneManufacturer,
                    flight.PlaneModel,
                    flight.PlaneRegistrationNumber,
                    flight.PlaneSeats,
                    flight.PlaneYearOfRegistration,
                    flight.PlaneState,
                    flight.Terminal);
            }

            // Test repository

            var data = new AirportSystemMsSqlData(new AirportSystemMsSqlDbContext());

            data.Airports.Add(new Airport
            {
                Code = "LBWN",
                Name = "Varna Airport"
            });

            data.Airports.Add(new Airport
            {
                Code = "LBSF",
                Name = "Sofia Airport"
            });

            data.Airlines.Add(new Airline
            {
                Name = "Bongo Air"
            });

            Console.WriteLine();
            Console.WriteLine("Airports:");
            Console.WriteLine("==========");
            
            foreach (var entity in data.Airports.GetAll())
            {
                Console.WriteLine("{0} - {1}", entity.Code, entity.Name);
            }

            Console.WriteLine("Airlines:");
            Console.WriteLine("==========");
            foreach (var entity in data.Airlines.GetAll())
            {
                Console.WriteLine("{0}", entity.Name);
            }

            // Test shedule updater
            var su = new ScheduleUpdater(data);
            su.UpdateScheduleFromFile("../../../SampleInputFiles/sample.xlsx", excelSer);
            Console.WriteLine();
            Console.WriteLine("FLIGHTS ADDDED!!!");
        }
    }
}
