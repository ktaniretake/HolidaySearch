namespace HolidaySearch.Models
{
  public class HolidaySearchData
  {
    public string? FromCity { get; set; }
    public string? FromAirportName { get; set; }
    public string? ToCity { get; set; }
    public string? ToAirportName { get; set; }
    public string Date { get; set; } = string.Empty;
    public int Duration { get; set; }
  }
}
