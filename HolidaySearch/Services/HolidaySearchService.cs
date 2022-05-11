using HolidaySearch.Data.Databases;
using HolidaySearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Services
{
  public class HolidaySearchService
  {
    public static List<IDatabase> _databases = new List<IDatabase>();
    public HolidaySearchService(List<IDatabase> databases)
    {
      _databases = databases;

      foreach (var database in _databases)
      {
        database.LoadDatabase();
      }
    }

    public List<Result> FindHoliday()
    {
      throw new NotImplementedException();
    }
  }
}