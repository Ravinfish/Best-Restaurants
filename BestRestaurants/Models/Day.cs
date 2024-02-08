using System.Collections.Generic;

namespace BestRestaurants.Models;

public class Day
{
  public int DayId { get; set; }
  public string Name { get; set;}
  string Time { get; set; }
  public List<DayService> JoinEntities { get;}
}