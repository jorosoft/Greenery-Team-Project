using System;
using AirportSystem.Contracts.Data;
using AirportSystem.Contracts.Data.Repositories;
using AirportSystem.Contracts.MainDll;
using AirportSystem.Contracts.Models;
using AirportSystem.Models;

namespace AirportSystem
{
    public class ScheduleUpdater : IScheduleUpdater
    {
        private readonly IAirportSystemMsSqlData msSqlData;
        private readonly IAirportSystemPSqlData pSqlData;
        private readonly IAirportSystemSqliteData sqliteData;

        public ScheduleUpdater(IAirportSystemMsSqlData msSqlData, IAirportSystemPSqlData pSqlData, IAirportSystemSqliteData sqliteData)
        {
            this.msSqlData = msSqlData;
            this.pSqlData = pSqlData;
            this.sqliteData = sqliteData;
        }

        public int UpdateScheduleFromFile(string filePath, IDeserializer deserializer)
        {
            var flights = deserializer.Deserialize(filePath);
            int counter = 0;

            foreach (var flight in flights)
            {
                int flightTypeId = this.msSqlData.FlightTypes.Add(new FlightType { Name = flight.FlightType });
                int airlineId = this.msSqlData.Airlines.Add(new Airline { Name = flight.Airline });
                int airportId = this.msSqlData.Airports.Add(new Airport { Name = flight.DestinationAirportName, Code = flight.DestinationAirportCode });
                int manufacturerId = this.msSqlData.Manufacturers.Add(new Manufacturer { Name = flight.PlaneManufacturer });
                int modelId = this.msSqlData.Models.Add(new Model { Name = flight.PlaneModel, Seats = flight.PlaneSeats });
                int planeId = this.msSqlData.Planes.Add(new Plane
                {
                    PlanePass = new PlanePassport
                    {
                        RegistrationNumber = flight.PlaneRegistrationNumber,
                        YearOfRegistration = flight.PlaneYearOfRegistration,
                        State = flight.PlaneState
                    },
                    ManufacturerId = manufacturerId,
                    ModelId = modelId,
                    AirlineId = airlineId
                });
                int terminalId = this.msSqlData.Terminals.Add(new Terminal { Name = flight.Terminal });
                this.msSqlData.Flights.Add(new Flight
                {
                    SheduledTime = flight.SheduledTime,
                    DestinationAirportId = airportId,
                    FlightTypeId = flightTypeId,
                    PlaneId = planeId,
                    TerminalId = terminalId
                });

                counter++;
            }

            return counter;
        }

        public void AddFlight(IFlight flight)
        {
            var flightToAdd = (Flight)flight;

            int flightTypeId = this.msSqlData.FlightTypes.Add(flightToAdd.FlightType);
            int airlineId = this.msSqlData.Airlines.Add(flightToAdd.Plane.Airlines);
            int airportId = this.msSqlData.Airports.Add(flightToAdd.DestinationAirport);
            int manufacturerId = this.msSqlData.Manufacturers.Add(flightToAdd.Plane.Manufacturers);
            int modelId = this.msSqlData.Models.Add(flightToAdd.Plane.Models);            
            int planeId = this.msSqlData.Planes.Add(new Plane
            {
                PlanePass = new PlanePassport
                {
                    RegistrationNumber = flightToAdd.Plane.PlanePassport.RegistrationNumber,
                    YearOfRegistration = flightToAdd.Plane.PlanePassport.YearOfRegistration,
                    State = flightToAdd.Plane.PlanePassport.State
                },
                ManufacturerId = manufacturerId,
                ModelId = modelId,
                AirlineId = airlineId
            });
            int terminalId = this.msSqlData.Terminals.Add(flightToAdd.Terminal);
            this.msSqlData.Flights.Add(new Flight
            {
                SheduledTime = flightToAdd.SheduledTime,
                DestinationAirportId = airportId,
                FlightTypeId = flightTypeId,
                PlaneId = planeId,
                TerminalId = terminalId
            });
        }

        public void UpdateFlight(IFlight flight)
        {
            throw new NotImplementedException();
        }
    }
}
