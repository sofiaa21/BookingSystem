namespace Model;

public class Resource
{
    public int Id { get;  set; }
    public string Name { get; private set; }
    public int Quantity { get; private set; }

    public Resource(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }

    private Resource(){}
}