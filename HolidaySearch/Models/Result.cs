using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Models
{
  public class Result
  {
    public double TotalPrice { get; set; }
    public Flight? Flight { get; set; }
    public Hotel? Hotel { get; set; }
  }
}
