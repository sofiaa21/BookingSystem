namespace Model;

public class Booking
{
    public int Id { get; private set; }
    public DateTime DateFrom { get; private set; }
    public DateTime DateTo { get; private set; }
    public int BookedQuantity { get; private set; }
    public int ResourceId { get; private set; }

    private Booking()
    {
        
    }

    public Booking(int id, DateTime dateFrom, DateTime dateTo, int bookedQuantity, int resourceId)
    {
        Id = id;
        DateFrom = dateFrom;
        DateTo = dateTo;
        BookedQuantity = bookedQuantity;
        ResourceId = resourceId;
    }
}