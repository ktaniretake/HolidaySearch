namespace HolidaySearch.Models
{
  public class HolidaySearchData
  {
    public string? FromCity { get; set; }
    public string? FromAirportName { get; set; }
    public string ToAirportName { get; set; } = string.Empty;
    public string Date { get; set; } = string.Empty;
    public int Duration { get; set; }
  }
}