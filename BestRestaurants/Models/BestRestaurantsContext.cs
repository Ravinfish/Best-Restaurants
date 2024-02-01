using Microsoft.EntityFrameworkCore;

namespace BestRestaurants.Models;
  public class BestRestaurantsContext : DbContext
  {
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Cuisine> Cuisines { get; set; }

    public DbSet<Review> Reviews { get; set; }
    public BestRestaurantsContext(DbContextOptions options) : base(options) { }
  }
