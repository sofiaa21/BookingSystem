namespace Model.DTOs;

public class ResourceGetByIdDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }

    public ResourceGetByIdDto(int id, string name, int quantity)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
    }
}