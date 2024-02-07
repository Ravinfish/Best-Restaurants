namespace BestRestaurants.Models;

public class RestaurantService
{
  public int RestaurantServiceId { get; set; }
  public int RestaurantId { get; set; }
  public Restaurant Restaurant { get; set; }
  public int ServiceId { get; set; }
  public Service Service { get; set; }
}