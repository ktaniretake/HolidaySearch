using HolidaySearch.Data.Databases;
using HolidaySearch.Models;
using HolidaySearch.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

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
    public void SearchHoliday_FindByFromAirportNameToAirportName_ValidData()
    {
      var holidaySeachData = new HolidaySearchData() 
      { 
        FromAirportName = "MAN",
        ToAirportName = "AGP",
        Date = "2023/07/01",
        Duration = 7
      };

      var resultsList = _holidaySearch.FindHoliday(holidaySeachData);

      var result = resultsList.First();

      Assert.AreEqual(826, result.TotalPrice);
      Assert.AreEqual(2, result.Flight.Id);
      Assert.AreEqual(9, result.Hotel.Id);
    }

    [Test]
    public void SearchHoliday_FindByFromCityToAirportName_ValidData()
    {
      var holidaySeachData = new HolidaySearchData()
      {
        FromCity = "London",
        ToAirportName = "PMI",
        Date = "2023/06/15",
        Duration = 10
      };

      var resultsList = _holidaySearch.FindHoliday(holidaySeachData);

      var result = resultsList.First();

      Assert.AreEqual(675, result.TotalPrice);
      Assert.AreEqual(6, result.Flight.Id);
      Assert.AreEqual(5, result.Hotel.Id);
    }

    [Test]
    public void SearchHoliday_FindByToAirportName_ValidData()
    {
      var holidaySeachData = new HolidaySearchData()
      {
        ToAirportName = "LPA",
        Date = "2022/11/10",
        Duration = 14
      };

      var resultsList = _holidaySearch.FindHoliday(holidaySeachData);

      var result = resultsList.First();

      Assert.AreEqual(1175, result.TotalPrice);
      Assert.AreEqual(7, result.Flight.Id);
      Assert.AreEqual(6, result.Hotel.Id);
    }
  }
}