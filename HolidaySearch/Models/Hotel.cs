using Newtonsoft.Json;

namespace HolidaySearch.Models
{
  public class Hotel
  {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    [JsonProperty(PropertyName = "arrival_date")]
    public DateTimeOffset ArrivalDate { get; set; }

    [JsonProperty(PropertyName = "price_per_night")]
    public double Price { get; set; }

    [JsonProperty(PropertyName = "local_airports")]
    public List<string> LocalAirportNames { get; set; } = new List<string>();
    public List<Airport> LocalAirports { get; set; } = new List<Airport>();
    public int Nights { get; set; }
  }
}