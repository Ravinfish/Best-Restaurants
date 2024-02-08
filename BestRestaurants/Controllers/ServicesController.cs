using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks.Dataflow;
using System;

namespace BestRestaurants.Controllers
{
  public class ServicesController : Controller
  {
    private readonly BestRestaurantsContext _db;
    public ServicesController(BestRestaurantsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Services.ToList());
    }

    public ActionResult Details(int id)
    {
      Service thisService = _db.Services
        .Include(service => service.JoinEntities)
        .ThenInclude(join => join.Restaurant)
        .Include(service => service.JoinEntity)
        .ThenInclude(join => join.Day)
        .FirstOrDefault(service => service.ServiceId == id);
      return View(thisService);
    }
    public ActionResult AddRestaurant(int id)
    {
      Service thisService = _db.Services.FirstOrDefault(services => services.ServiceId == id);
      ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantId", "Name");
      return View(thisService);
    }
    [HttpPost]
    public ActionResult AddRestaurant(Service service, int restaurantId)
    {
#nullable enable
      RestaurantService? joinEntity = _db.RestaurantServices.FirstOrDefault(join => (join.RestaurantId == restaurantId && join.ServiceId == service.ServiceId));
#nullable disable
      if (joinEntity == null && restaurantId != 0)
      {
        _db.RestaurantServices.Add(new RestaurantService() { RestaurantId = restaurantId, ServiceId = service.ServiceId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = service.ServiceId });
    }
    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      RestaurantService joinEntry = _db.RestaurantServices.FirstOrDefault(entry => entry.RestaurantServiceId == joinId);
      _db.RestaurantServices.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddDay(int id)
    {
      Service thisService = _db.Services.FirstOrDefault(services => services.ServiceId == id);
      List<Day> days = _db.Days.ToList();
      ViewBag.Days = days;
      return View(thisService);
    }

    [HttpPost]
    public ActionResult AddDay(Service service, int[] dayIds)
    {
      if (dayIds != null && dayIds.Length > 0)
      {
        foreach (var dayId in dayIds)
        {
#nullable enable
          DayService? joinEntity = _db.DayServices.FirstOrDefault(join => join.DayId == dayId && join.ServiceId == service.ServiceId);
#nullable disable
          if (joinEntity == null)
          {
            _db.DayServices.Add(new DayService() { DayId = dayId, ServiceId = service.ServiceId });
          }
          _db.SaveChanges();
        }
        return RedirectToAction("Details", new { id = service.ServiceId });
      }
      else
      {
        return RedirectToAction("Index", "Home");
      }
    }
  }
}