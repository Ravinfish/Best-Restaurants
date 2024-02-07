using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks.Dataflow;

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
        .FirstOrDefault(service => service.ServiceId == id);
      return View(thisService);
    }
    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Service service)
    {
      _db.Services.Add(service);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}