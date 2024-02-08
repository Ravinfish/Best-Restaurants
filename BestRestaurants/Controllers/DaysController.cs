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

  public ActionResult Details(int id)
  {
    Day thisDay = _db.Days
    .Include(day => day.JoinEntities)
    .ThenInclude(join => join.Service)
    .FirstOrDefault(day => day.DayId == id);
    return View(thisDay);
  }
  public ActionResult AddService(int id)
  {
    Day thisDay = _db.Days.FirstOrDefault(days => days.DayId == id);
    ViewBag.ServiceId = new SelectList(_db.Services, "ServiceId", "Type");
    return View(thisDay);
  }
  [HttpPost]
  public ActionResult AddService(Day day, int serviceId)
  {
    #nullable enable
    DayService? joinEntity = _db.DayServices.FirstOrDefault(join => (join.ServiceId == serviceId && join.DayId == day.DayId));
    #nullable disable
    if (joinEntity == null && serviceId != 0)
    {
      _db.DayServices.Add(new DayService() { ServiceId = serviceId, DayId = day.DayId });
      _db.SaveChanges();
    }
    return RedirectToAction("Details", new { id = day.DayId });
  }
}