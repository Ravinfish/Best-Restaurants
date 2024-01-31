namespace BestRestaurants.Models;

public class Restaurant
{
  public int RestaurantId { get; set; }
  public string Name { get; set; }
  public string Type { get; set; }
  public string Neighborhood { get; set; }
  public string Notes { get; set; }
}