using System.Collections.Generic;

namespace BestRestaurants.Models;

public class Review
{
  public int ReviewId { get; set; }
  public string Feedback { get; set; }
  public string Rating { get; set; }

  public int RestaurantId { get; set; }
  public Restaurant Restaurant { get; set; }

  // public List<Restaurant> Restaurants { get; set; }
}