using HolidaySearch.Data.Databases;
using HolidaySearch.Models;
using System.Globalization;

namespace HolidaySearch.Services
{
  public class HolidaySearchService
  {
    public static List<IDatabase> _databases = new List<IDatabase>();
    public List<Result> _results = new List<Result>();
    public HolidaySearchService(List<IDatabase> databases)
    {
      _databases = databases;

      foreach (var database in _databases)
      {
        database.LoadDatabase();
      }
    }

    public void FindHoliday(HolidaySearchData holidaySearchData)
    {
      var flightsDb = (FlightsDb)_databases.Find(x => x.GetDbName() == "FlightsDb");
      var hotelsDb = (HotelsDb)_databases.Find(x => x.GetDbName() == "HotelsDb");

      var flights = FindFlights(holidaySearchData, flightsDb);

      foreach (var flight in flights)
      {
        var hotels = FindHotels(flight, holidaySearchData.Duration, hotelsDb);

        if (hotels == null)
          throw new Exception("There are no hotels by requirements.");

        foreach (var hotel in hotels)
        {
          _results.Add(new Result(flight, hotel));
        }
      }
    }

    private List<Flight> FindFlights(HolidaySearchData holidaySearchData, FlightsDb? database)
    {
      if (database == null)
        throw new ArgumentNullException(nameof(database));

      var flights = database.GetFlightsList().OrderBy(x => x.Price).ToList();
      var result = new List<Flight>();

      var searchedDate = DateTime.ParseExact(holidaySearchData.Date, "yyyy/MM/dd", CultureInfo.InvariantCulture);

      foreach (var flight in flights)
      {
        if (holidaySearchData.FromCity != null)
        {
          if (flight.DepartureAirport.City != holidaySearchData.FromCity)
            continue;
        }

        if (holidaySearchData.FromAirportName != null)
        {
          if (flight.DepartureAirport.Name != holidaySearchData.FromAirportName)
            continue;
        }

        if (holidaySearchData.ToAirportName != null)
        {
          if (flight.DestinationAirport.Name != holidaySearchData.ToAirportName)
            continue;
        }

        if (flight.DepartureDate != searchedDate)
          continue;
        
        result.Add(flight);
      }

      return result;
    }

    private List<Hotel> FindHotels(Flight? flight, int duration, HotelsDb? database)
    {
      if (flight == null)
        throw new ArgumentNullException(nameof(flight));

      if (database == null)
        throw new ArgumentNullException(nameof(database));

      var hotels = database.GetHotelsList();
      var result = new List<Hotel>();

      foreach (var hotel in hotels)
      {
        foreach (var airport in hotel.LocalAirports)
        {
          if (airport.Name != flight.DestinationAirport.Name)
            continue;

          if (hotel.ArrivalDate.Date != flight.DepartureDate.Date)
            continue;

          if (hotel.Nights != duration)
            continue;

          result.Add(hotel);
        }
      }

      return result;
    }
  }
}