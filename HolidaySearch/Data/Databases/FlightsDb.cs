using HolidaySearch.Models;
using HolidaySearch.Services;
using Newtonsoft.Json;

namespace HolidaySearch.Data.Databases
{
  public class FlightsDb : IDatabase
  {
    private string DbName = "FlightsDb";
    public static List<Flight>? _flights = new List<Flight>();
    private AirportService _airportService;

    public FlightsDb(AirportService airportSpreader)
    {
      _airportService = airportSpreader;
    }
    public void LoadDatabase()
    {
      var path = VisualStudioProvider.TryGetSolutionDirectoryInfo().FullName + @"\HolidaySearch\Data\JsonFiles\FlightsData.json";

      if (path == null) 
        throw new ArgumentNullException(nameof(path));

      if (File.Exists(path))
      {
        using (StreamReader r = new StreamReader(path))
        {
          _flights = JsonConvert.DeserializeObject<List<Flight>>(r.ReadToEnd());
        }

        if (_flights != null)
          LoadDataAboutAirports();
      }

      return;
    }

    private void LoadDataAboutAirports()
    {
      if (_flights == null)
        throw new ArgumentNullException();

      foreach (var flight in _flights)
      {
        flight.DepartureAirport = _airportService.GetAirportDataByName(flight.From);
        flight.DestinationAirport = _airportService.GetAirportDataByName(flight.To);
      }

      return;
    }

    public string GetDbName()
    {
      return DbName;
    }

    public List<Flight> GetFlightsList()
    {
      if (_flights == null)
        throw new NullReferenceException();

      return _flights;
    }
  }
}