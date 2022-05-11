using Newtonsoft.Json;

namespace HolidaySearch.Models
{
  public class Flight
  {
    public int Id { get; set; }
    public string Airline { get; set; } = string.Empty;
    public string From { get; set; }
    public Airport DepartureAirport { get; set; }
    public string To { get; set; }
    public Airport DestinationAirport { get; set; }
    public double Price { get; set; }

    [JsonProperty(PropertyName = "departure_date")]
    public DateTime DepartureDate { get; set; }
  }
}
