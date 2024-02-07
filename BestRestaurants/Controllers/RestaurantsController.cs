using System.Collections.Generic;
using System.Linq;
using BestRestaurants.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks; //for search bar

namespace BestRestaurants.Controllers
{
  public class RestaurantsController : Controller
  {
    private readonly BestRestaurantsContext _db;

    public RestaurantsController(BestRestaurantsContext db)
    {
      _db = db;
    }

    private async Task<List<Restaurant>> SearchMethod(string query)
    {
      IQueryable<Restaurant> results = _db.Set<Restaurant>().Include(resturant => resturant.Cuisine);

      if (query != null)
      {
        return await results?.Where(restaurant => restaurant.Name.Contains(query)).ToListAsync();
      }
      else
      {
        return await results.ToListAsync();
      }
    }

    public async Task<IActionResult> Index(string query)
    {
      List<Restaurant> resultList = await SearchMethod(query);
      return View(resultList);
    }

    //old index before search bar
    // public ActionResult Index()
    // {
    //   List<Restaurant> model = _db.Restaurants.Include(restaurant => restaurant.Cuisine).ToList();
    //   ViewBag.PageTitle = "View All Items";
    //   return View(model);
    // }
    public ActionResult Create()
    {
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Restaurant restaurant)
    {
      if (restaurant.CuisineId == 0)
      {
        return RedirectToAction("Create");
      }
      _db.Restaurants.Add(restaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
     public ActionResult Details(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants
      .Include(restaurant => restaurant.Cuisine)
      .Include(restaurant => restaurant.Reviews)
      .Include(restaurant => restaurant.JoinEntities)
      .ThenInclude(join => join.Service) 
      .FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(thisRestaurant);
    }

    public ActionResult Edit(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
      return View(thisRestaurant);
    }

    [HttpPost]
    public ActionResult Edit(Restaurant restaurant)
    {
      _db.Restaurants.Update(restaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(thisRestaurant);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      _db.Restaurants.Remove(thisRestaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}