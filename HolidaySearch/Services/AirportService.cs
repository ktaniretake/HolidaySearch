using HolidaySearch.Models;

namespace HolidaySearch.Services
{
  public class AirportService
  {
    public Airport GetAirportDataByName(string airportName)
    {
      Airport? airport;

      switch (airportName)
      {
        case "MAN":
          airport = new Airport(airportName, "Great Britain", "Manchester");
          break;
        case "LTN":
          airport = new Airport(airportName, "Great Britain", "London");
          break;
        case "LGW":
          airport = new Airport(airportName, "Great Britain", "London");
          break;
        case "TFS":
          airport = new Airport(airportName, "Spain", "Santa Cruz de Tenerife");
          break;
        case "AGP":
          airport = new Airport(airportName, "Spain", "Malaga");
          break;
        case "PMI":
          airport = new Airport(airportName, "Spain", "Malorka");
          break;
        case "LPA":
          airport = new Airport(airportName, "Spain", "Las Palmas");
          break;
        default: 
          throw new ArgumentException("Unknown airport's name.");
      }

      return airport;
    }
  }
}