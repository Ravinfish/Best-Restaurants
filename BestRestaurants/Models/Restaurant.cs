using System.Collections.Generic;

namespace BestRestaurants.Models;


public class Restaurant
{
  public int RestaurantId { get; set; }
  public string Name { get; set; }
  public string Type { get; set; }
  public string Neighborhood { get; set; }
  public string Notes { get; set; }
  public Cuisine Cuisine { get; set; }
  public int CuisineId { get; set; }
  public List<Review> Reviews { get; set; }
  //do we need this for res.contr line 69??? below
  // public Review Review { get; set; }
  // public int ReviewId { get; set;}
}