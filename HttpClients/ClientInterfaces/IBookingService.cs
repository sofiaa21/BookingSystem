namespace HttpClients.ClientInterfaces;

using Model;
using Model.DTOs;

public interface IBookingService
{
    public Task CreateBooking(BookingDto dto);


    Task<ICollection<Booking>> GetAsync(int? id=null, DateTime? start=null, DateTime? end=null, int? quantity=null, int? resource=null);

}