using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System;
using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BestRestaurants.Controllers;

public class HomeController : Controller
{
  public ActionResult Index()
  {
    return View();
    // public async Task<IActionResult> Index(string searchString)
    // {
      // IQueryable<Restaurant> model = from m in _db.Restaurants
      //                         .Include(restaurant => restaurant.Cuisine)
      //                          select m;

      // if (!String.IsNullOrEmpty(searchString))
      // {
      //   model = model.Where(s => s.Name!.Contains(searchString));
      // }
      // return View(await model.ToListAsync());
    }

  
  }
