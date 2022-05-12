namespace HolidaySearch.Models
{
  public class Result
  {
    public double TotalPrice { get; set; }
    public Flight Flight { get; set; }
    public Hotel Hotel { get; set; }

    public Result(Flight flight, Hotel hotel)
    {
      Flight = flight;
      Hotel = hotel;
      TotalPrice = GetTotalPrice();
    }

    private double GetTotalPrice()
    {
      return Flight.Price + (Hotel.Price * Hotel.Nights);
    }
  }
}