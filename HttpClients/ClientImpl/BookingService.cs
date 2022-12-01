namespace HttpClients.ClientImpl;

using System.Net.Http.Json;
using System.Text.Json;
using ClientInterfaces;
using Model;
using Model.DTOs;

public class BookingService:IBookingService
{
    private readonly HttpClient client;

    public BookingService(HttpClient client)
    {
        this.client = client;
    }
    public async Task CreateBooking(BookingDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/Booking", dto);
        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task<ICollection<Booking>> GetAsync(int? id = null, DateTime? start = null, DateTime? end = null,
        int? quantity = null, int? resource = null)
    {
        string query = ConstructQuery(id,start,end,quantity,resource);

        HttpResponseMessage response = await client.GetAsync($"/Booking" + query);
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<Booking> bookings = JsonSerializer.Deserialize<ICollection<Booking>>(content,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        return bookings;
    }

    private string ConstructQuery(int? id, DateTime? start, DateTime? end, int? quantity, int? resource)
    {
        string query = "";
        if (id != null)
        {
            query += $"id={id}";
        }
        if (start != null)
        {
            query += string.IsNullOrEmpty(query) ? "?" : "&";
            query += $"start={start}";
        }
        if (end != null)
        {
            query += string.IsNullOrEmpty(query) ? "?" : "&";
            query += $"end={end}";
        }

        if (quantity != null)
        {
            query += string.IsNullOrEmpty(query) ? "?" : "&";
            query += $"quantity{quantity}";
        }

        if (resource != null)
        {
            query += string.IsNullOrEmpty(query) ? "?" : "&";
            query += $"resource{resource}";
        }
        

        return query;
    }
}