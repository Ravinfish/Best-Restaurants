namespace BestRestaurants.Models;

public class DayService
{
  public int DayServiceId { get; set; }
  public int DayId { get; set; }
  public int ServiceId { get; set; }
  public Day Day { get; set;}
  public Service Service { get; set; }
}