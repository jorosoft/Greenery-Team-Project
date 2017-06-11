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
            
            foreach (var entity in msSqlData.Airports.GetAll())
            {
                Console.WriteLine("{0} - {1}", entity.Code, entity.Name);
            }

            Console.WriteLine("Airlines:");
            Console.WriteLine("==========");
            foreach (var entity in msSqlData.Airlines.GetAll())
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
        }
    }
}
