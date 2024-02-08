using System.Collections.Generic;

namespace BestRestaurants.Models;


public class Restaurant
{
  public int RestaurantId { get; set; }
  public string Name { get; set; }
  public string Neighborhood { get; set; }
  public string Notes { get; set; }
  public Cuisine Cuisine { get; set; }
  public int CuisineId { get; set; }
  public List<Review> Reviews { get; set; }
  public List<RestaurantService> JoinEntities { get; }
  public List<DayRestaurant> JoinEntity { get; }
}