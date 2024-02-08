using Microsoft.EntityFrameworkCore;

namespace BestRestaurants.Models;
public class BestRestaurantsContext : DbContext
{
  public DbSet<Restaurant> Restaurants { get; set; }
  public DbSet<Cuisine> Cuisines { get; set; }

  public DbSet<Review> Reviews { get; set; }
  public DbSet<Service> Services { get; set; }
  public DbSet<RestaurantService> RestaurantServices { get; set; }
  public DbSet<Day> Days { get; set; }
  public DbSet<DayService> DayServices { get; set; }
  public BestRestaurantsContext(DbContextOptions options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.Entity<Service>()
    .HasData(
      new Service { ServiceId = 1, Type = "Breakfast" },
      new Service { ServiceId = 2, Type = "Brunch" },
      new Service { ServiceId = 3, Type = "Lunch" },
      new Service { ServiceId = 4, Type = "Happy Hour" },
      new Service { ServiceId = 5, Type = "Dinner" }
    );

    builder.Entity<Day>()
    .HasData(
      new Day { DayId = 1, Name = "Sunday" },
      new Day { DayId = 2, Name = "Monday" },
      new Day { DayId = 3, Name = "Tuesday" },
      new Day { DayId = 4, Name = "Wednesday" },
      new Day { DayId = 5, Name = "Thursday" },
      new Day { DayId = 6, Name = "Friday" },
      new Day { DayId = 7, Name = "Saturday" }
    );
  }
}
