using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;

namespace BestRestaurants.Controllers;

public class HomeController : Controller
{
  public ActionResult Index()
  {
    return View();
  }
}