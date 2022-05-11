using HolidaySearch.Models;
using HolidaySearch.Services;
using Newtonsoft.Json;

namespace HolidaySearch.Data.Databases
{
  public class HotelsDb : IDatabase
  {
    public static List<Hotel>? _hotels = new List<Hotel>();
    private AirportService _airportService;

    public HotelsDb(AirportService airportSpreader)
    {
      _airportService = airportSpreader;
    }

    public void LoadDatabase()
    {
      var path = VisualStudioProvider.TryGetSolutionDirectoryInfo().FullName + @"\HolidaySearch\Data\JsonFiles\HotelsData.json";

      if (path == null)
        throw new ArgumentNullException(nameof(path));

      if (File.Exists(path))
      {
        using (StreamReader r = new StreamReader(path))
        {
          _hotels = JsonConvert.DeserializeObject<List<Hotel>>(r.ReadToEnd());
        }

        if (_hotels != null)
          LoadDataAboutAirports();
      }

      return;
    }

    private void LoadDataAboutAirports()
    {
      if (_hotels == null)
        throw new ArgumentNullException();

      foreach (var hotel in _hotels)
      {
        foreach (var name in hotel.LocalAirportNames)
        {
          hotel.LocalAirports.Add(_airportService.GetAirportDataByName(name));
        }        
      }

      return;
    }
  }
}