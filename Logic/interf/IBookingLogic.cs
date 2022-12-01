namespace Logic;

using Model;

public interface IBookingLogic
{
    Task<Booking> CreateBookingAsync(Booking booking);
    
}