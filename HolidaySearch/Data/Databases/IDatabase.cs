namespace HolidaySearch.Data.Databases
{
  public interface IDatabase
  {
    void LoadDatabase();
    string GetDbName();
  }
}