namespace DataAccess.DAOs.impl;

using interf;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model;

public class BookingDao:IBookingDao
{
    private readonly DbBookingSystemContext context;

    public BookingDao(DbBookingSystemContext context)
    {
        this.context = context;
    }

    public async Task<Booking> CreateBooking(Booking bookingToCreate)
    {
        EntityEntry<Booking> added = await context.Bookings.AddAsync(bookingToCreate);
        await context.SaveChangesAsync();
        return added.Entity;
    }
}