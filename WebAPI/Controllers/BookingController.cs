namespace WebAPI.Controllers;

using Logic;
using Microsoft.AspNetCore.Mvc;
using Model;

[ApiController]
[Route("[controller]")]
public class BookingController:ControllerBase
{
    private readonly IBookingLogic bookingLogic;

    public BookingController(IBookingLogic bookingLogic)
    {
        this.bookingLogic = bookingLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Booking>> CreateAsync([FromBody] Booking booking)
    {
        try
        {
            Booking created = await bookingLogic.CreateBookingAsync(booking);
            return Created($"/bookings/{created.Id}", created);
        }

        catch(Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}