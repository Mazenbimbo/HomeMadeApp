public class Product
{
    private int NextId;
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product()
    {
        NextId++;
        Id = NextId;
    }
}