﻿// <auto-generated />
using BestRestaurants.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BestRestaurants.Migrations
{
    [DbContext(typeof(BestRestaurantsContext))]
    partial class BestRestaurantsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BestRestaurants.Models.Cuisine", b =>
                {
                    b.Property<int>("CuisineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("CuisineId");

                    b.ToTable("Cuisines");
                });

            modelBuilder.Entity("BestRestaurants.Models.Day", b =>
                {
                    b.Property<int>("DayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("DayId");

                    b.ToTable("Days");

                    b.HasData(
                        new
                        {
                            DayId = 1,
                            Name = "Sunday"
                        },
                        new
                        {
                            DayId = 2,
                            Name = "Monday"
                        },
                        new
                        {
                            DayId = 3,
                            Name = "Tuesday"
                        },
                        new
                        {
                            DayId = 4,
                            Name = "Wednesday"
                        },
                        new
                        {
                            DayId = 5,
                            Name = "Thursday"
                        },
                        new
                        {
                            DayId = 6,
                            Name = "Friday"
                        },
                        new
                        {
                            DayId = 7,
                            Name = "Saturday"
                        });
                });

            modelBuilder.Entity("BestRestaurants.Models.DayService", b =>
                {
                    b.Property<int>("DayServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DayId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("DayServiceId");

                    b.HasIndex("DayId");

                    b.HasIndex("ServiceId");

                    b.ToTable("DayServices");
                });

            modelBuilder.Entity("BestRestaurants.Models.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CuisineId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Neighborhood")
                        .HasColumnType("longtext");

                    b.Property<string>("Notes")
                        .HasColumnType("longtext");

                    b.HasKey("RestaurantId");

                    b.HasIndex("CuisineId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("BestRestaurants.Models.RestaurantService", b =>
                {
                    b.Property<int>("RestaurantServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("RestaurantServiceId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("ServiceId");

                    b.ToTable("RestaurantServices");
                });

            modelBuilder.Entity("BestRestaurants.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Feedback")
                        .HasColumnType("longtext");

                    b.Property<string>("Rating")
                        .HasColumnType("longtext");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("BestRestaurants.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.HasKey("ServiceId");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            ServiceId = 1,
                            Type = "Breakfast"
                        },
                        new
                        {
                            ServiceId = 2,
                            Type = "Brunch"
                        },
                        new
                        {
                            ServiceId = 3,
                            Type = "Lunch"
                        },
                        new
                        {
                            ServiceId = 4,
                            Type = "Happy Hour"
                        },
                        new
                        {
                            ServiceId = 5,
                            Type = "Dinner"
                        });
                });

            modelBuilder.Entity("BestRestaurants.Models.DayService", b =>
                {
                    b.HasOne("BestRestaurants.Models.Day", "Day")
                        .WithMany("JoinEntities")
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BestRestaurants.Models.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Day");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("BestRestaurants.Models.Restaurant", b =>
                {
                    b.HasOne("BestRestaurants.Models.Cuisine", "Cuisine")
                        .WithMany("Restaurants")
                        .HasForeignKey("CuisineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuisine");
                });

            modelBuilder.Entity("BestRestaurants.Models.RestaurantService", b =>
                {
                    b.HasOne("BestRestaurants.Models.Restaurant", "Restaurant")
                        .WithMany("JoinEntities")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BestRestaurants.Models.Service", "Service")
                        .WithMany("JoinEntities")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("BestRestaurants.Models.Review", b =>
                {
                    b.HasOne("BestRestaurants.Models.Restaurant", "Restaurant")
                        .WithMany("Reviews")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("BestRestaurants.Models.Cuisine", b =>
                {
                    b.Navigation("Restaurants");
                });

            modelBuilder.Entity("BestRestaurants.Models.Day", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("BestRestaurants.Models.Restaurant", b =>
                {
                    b.Navigation("JoinEntities");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("BestRestaurants.Models.Service", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
