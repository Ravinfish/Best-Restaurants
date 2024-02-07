using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Collections.Generic;
using System.Linq;

namespace BestRestaurants.Controllers;

public class HomeController : Controller
{
  private readonly BestRestaurantsContext _db;
  public HomeController(BestRestaurantsContext db)
  {
    _db = db;
  }
  [HttpGet("/")]
  public ActionResult Index()
  {
    Cuisine[] cuisines = _db.Cuisines.ToArray();
    Restaurant[] restaurants = _db.Restaurants.ToArray();
    Service[] services = _db.Services.ToArray();
    Dictionary<string,object[]> model = new Dictionary<string, object[]>();
    model.Add("cuisines", cuisines);
    model.Add("restaurants", restaurants);
    model.Add("services", services);
    return View(model);

  }

}
