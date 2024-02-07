using System.Collections.Generic;

namespace BestRestaurants.Models;

public class Service 
{
  public int ServiceId { get; set; }
  public string Type { get; set; }
  public string Day { get; set; }
  public List<RestaurantService> JoinEntities { get;}
}