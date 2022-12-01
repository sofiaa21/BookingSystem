namespace Logic.impl;

using DataAccess.DAOs.impl;
using DataAccess.DAOs.interf;
using Model;

public class BookingLogic:IBookingLogic
{
    private readonly IBookingDao dao;

    public BookingLogic(IBookingDao dao)
    {
        this.dao = dao;
    }
    
    public async Task<Booking> CreateBookingAsync(Booking booking)
    {
        Booking newBooking = new Booking(booking.Id, booking.DateFrom, booking.DateTo, booking.BookedQuantity,
            booking.ResourceId);
        Booking createdBooking = await dao.CreateBooking(newBooking);
        return createdBooking;

    }
}