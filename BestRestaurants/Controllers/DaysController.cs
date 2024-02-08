using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BestRestaurants.Controllers;

public class DaysController : Controller 
{
  private readonly BestRestaurantsContext _db;

  public DaysController(BestRestaurantsContext db)
  {
    _db = db;
  }
  public ActionResult Index()
  {
    return View(_db.Days.ToList());
  }
}