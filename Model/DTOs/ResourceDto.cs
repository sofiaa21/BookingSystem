namespace Model.DTOs;

public class ResourceDto
{
    public string? Name { get; }
    public int? Quantity { get; }

    public ResourceDto(string? name, int? quantity)
    {
        Name = name;
        Quantity = quantity;
    }
}