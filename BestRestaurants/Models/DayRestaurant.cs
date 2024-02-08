namespace BestRestaurants.Models;

public class DayRestaurant
{
  public int DayRestaurantId { get; set; }
  public int DayId { get; set; }
  public Day Day { get; set; }
  public int RestaurantId { get; set; }
  public Restaurant Restaurant { get; set; }
}