namespace DataAccess.DAOs.interf;

using Model;

public interface IBookingDao
{
    Task<Booking> CreateBooking(Booking bookingToCreate);
}