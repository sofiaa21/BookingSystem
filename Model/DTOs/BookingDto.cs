namespace Model.DTOs;

public class BookingDto
{
    public int Id { get; set; }
    public DateTime DateFrom { get;  set; }
    public DateTime DateTo { get;  set; }
    public int BookedQuantity { get;  set; }
    public int ResourceId { get;  set; }

    public BookingDto(int id, DateTime dateFrom, DateTime dateTo, int bookedQuantity, int resourceId)
    {
        Id = id;
        DateFrom = dateFrom;
        DateTo = dateTo;
        BookedQuantity = bookedQuantity;
        ResourceId = resourceId;
    }
}