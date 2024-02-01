using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BestRestaurants.Controllers;

public class ReviewsController: Controller
{
  private readonly BestRestaurantsContext _db;
  public ReviewsController(BestRestaurantsContext db)
  {
    _db = db;
  }
  public ActionResult Index()
  {
    List<Review> model = _db.Reviews
                          .Include(review => review.Restaurant)
                          .ToList();
    return View(model);
  }

   public ActionResult Create()
    {
      ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Review review)
    {
      if (review.RestaurantId == 0)
      {
        return RedirectToAction("Create");
      }
      _db.Reviews.Add(review);
      _db.SaveChanges();
      return RedirectToAction("Restaurant");
    }
    
    public ActionResult Details(int id)
    {
      Review thisReview = _db.Reviews
      .Include(review => review.Restaurant)
      .FirstOrDefault(review => review.ReviewId == id);
      return View(thisReview);
    }

    public ActionResult Edit(int id)
    {
      Review thisReview = _db.Reviews.FirstOrDefault(review => review.ReviewId == id);
      ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantId", "Name");
      return View(thisReview);
    }

    [HttpPost]
    public ActionResult Edit(Review review)
    {
      _db.Reviews.Update(review);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Review thisReview = _db.Reviews.FirstOrDefault(review => review.ReviewId == id);
      return View(thisReview);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Review thisReview = _db.Reviews.FirstOrDefault(review => review.ReviewId == id);
      _db.Reviews.Remove(thisReview);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
}