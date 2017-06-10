using System;
using System.Collections.Generic;
using System.IO;
using AirportSystem.Contracts.MainDll;
using AirportSystem.Contracts.Models;
using AirportSystem.Models.DTO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace AirportSystem.Converters
{
    public class ExcelDeserializer : IDeserializer
    {
        public IEnumerable<IFlightDTO> Deserialize(string filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException("No input file name is given!");
            }

            var dataSheet = this.GetDataSheet(filePath);
            List<IFlightDTO> readData = new List<IFlightDTO>();

            for (int row = 1; row <= dataSheet.LastRowNum; row++)
            {
                var flightDataRow = dataSheet.GetRow(row);
                FlightDTO flightData;

                if (flightDataRow == null)
                {
                    throw new ArgumentNullException($"Cell/s without data at row {row}!");
                }

                try
                {
                    flightData = this.GetFlightDataFromRow(flightDataRow);
                }
                catch (FormatException)
                {
                    throw new FormatException($"Wrong data at row {row}!");
                }

                readData.Add(flightData);
            }

            return readData;
        }

        private ISheet GetDataSheet(string filePath)
        {
            XSSFWorkbook workBook;

            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                workBook = new XSSFWorkbook(file);
            }

            ISheet sheet = workBook.GetSheet("Sheet1");

            return sheet;
        }

        private FlightDTO GetFlightDataFromRow(IRow dataSheetRow)
        {
            var flightDTO = new FlightDTO();

            flightDTO.SheduledTime = DateTime.Parse(dataSheetRow.GetCell(0).StringCellValue);
            flightDTO.DestinationAirportCode = dataSheetRow.GetCell(1).StringCellValue;
            flightDTO.DestinationAirportName = dataSheetRow.GetCell(2).StringCellValue;
            flightDTO.FlightType = dataSheetRow.GetCell(3).StringCellValue;
            flightDTO.PlaneManufacturer = dataSheetRow.GetCell(4).StringCellValue;
            flightDTO.PlaneModel = dataSheetRow.GetCell(5).StringCellValue;
            flightDTO.PlaneSeats = (int)dataSheetRow.GetCell(6).NumericCellValue;
            flightDTO.PlaneRegistrationNumber = dataSheetRow.GetCell(7).StringCellValue;
            flightDTO.PlaneYearOfRegistration = (int)dataSheetRow.GetCell(8).NumericCellValue;
            flightDTO.PlaneState = dataSheetRow.GetCell(9).StringCellValue;
            flightDTO.Airline = dataSheetRow.GetCell(10).StringCellValue;
            flightDTO.Terminal = dataSheetRow.GetCell(11).StringCellValue;

            return flightDTO;
        }
    }
}
