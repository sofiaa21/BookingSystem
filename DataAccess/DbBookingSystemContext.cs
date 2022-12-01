namespace DataAccess;

using Microsoft.EntityFrameworkCore;
using Model;

public class DbBookingSystemContext:DbContext
{
    public DbSet<Resource> Resources { get; set; }
    public DbSet<Booking> Bookings { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=../DataAccess/BookingSystem.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Resource>().HasKey(resource => resource.Id);
        modelBuilder.Entity<Booking>().HasKey(booking => booking.Id);
    }
}