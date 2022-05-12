namespace HolidaySearch.Models
{
  public class Airport
  {
    public string Name { get; set; }
    public string Country { get; set; }
    public string City { get; set; }

    public Airport(string name, string country, string city)
    {
      Name = name;
      Country = country;
      City = city;
    }
  }
}