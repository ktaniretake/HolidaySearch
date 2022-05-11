using HolidaySearch.Data.Databases;
using HolidaySearch.Services;
using NUnit.Framework;
using System.Collections.Generic;

namespace HolidaySearch.Tests
{
  public class HolidaySearchTests
  {
    private HolidaySearchService _holidaySearch;

    [SetUp]
    public void Setup()
    {
      var airportService = new AirportService();
      var databases = new List<IDatabase>(){ new FlightsDb(airportService), new HotelsDb(airportService) };
      _holidaySearch = new HolidaySearchService(databases);
    }

    [Test]
    public void Test1()
    {

      //_holidaySearch.FindHoliday();
      
      Assert.Pass();
    }
  }
}