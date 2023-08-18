using Microsoft.EntityFrameworkCore;
using CreekRiver.Models;
using System.Collections.Generic;
using System;

public class CreekRiverDbContext : DbContext
{

    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Campsite> Campsites { get; set; }
    public DbSet<CampsiteType> CampsiteTypes { get; set; }

    public CreekRiverDbContext(DbContextOptions<CreekRiverDbContext> context) : base(context)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with campsite types
        modelBuilder.Entity<CampsiteType>().HasData(new CampsiteType[]
        {
        new CampsiteType {Id = 1, CampsiteTypeName = "Tent", FeePerNight = 15.99M, MaxReservationDays = 7},
        new CampsiteType {Id = 2, CampsiteTypeName = "RV", FeePerNight = 26.50M, MaxReservationDays = 14},
        new CampsiteType {Id = 3, CampsiteTypeName = "Primitive", FeePerNight = 10.00M, MaxReservationDays = 3},
        new CampsiteType {Id = 4, CampsiteTypeName = "Hammock", FeePerNight = 12M, MaxReservationDays = 7},
        });

        modelBuilder.Entity<Campsite>().HasData(new Campsite[]
        {
        new Campsite {Id = 1, CampsiteTypeId = 1, Nickname = "Barred Owl", ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg"},
        new Campsite {Id = 2, CampsiteTypeId = 2, Nickname = "Clearview", ImageUrl="https://cdn.mchn.io/12/image/Camping.jpg"},
        new Campsite {Id = 3, CampsiteTypeId = 3, Nickname = "MudFoot", ImageUrl="https://assets.bedful.com/images/a688734b76b7738bda83d4684fac0482976ae6dd/large/the-best-riverside-campsites-in-scotland/the-best-riverside-campsites-in-scotland.jpg"},
        new Campsite {Id = 4, CampsiteTypeId = 4, Nickname = "Solitary", ImageUrl="https://media.blogto.com/articles/2017725-lake-superior.jpg?cmd=resize_then_crop&quality=70&w=2048&height=1365"},
        new Campsite {Id = 5, CampsiteTypeId = 5, Nickname = "Chillwind", ImageUrl="https://blog-assets.thedyrt.com/uploads/2019/01/shutterstock_242371765-1-1.jpg"},
        new Campsite {Id = 6, CampsiteTypeId = 6, Nickname = "HangingLights", ImageUrl="http://unique-weird.weebly.com/uploads/9/3/9/5/9395176/521308189.jpg"},
        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
            new UserProfile {Id = 1, FirstName = "Marco", LastName = "Lorenzo", Email = "MLorenzo@gmail.com", }
        });

        modelBuilder.Entity<Reservation>().HasData(new Reservation[]
        {
            new Reservation {Id = 1, CampsiteId = 1, UserProfileId = 1, CheckinDate = new DateTime(2021, 3, 15), CheckoutDate = new DateTime(2021, 3, 18) }
        });
    }
}