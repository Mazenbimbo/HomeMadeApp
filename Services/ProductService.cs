public class ProductService
{
    public readonly AppDbContext db;

    public ProductService(AppDbContext db)
    {
        this.db = db;
    }

    public Product CreateProduct(CreateProductDto dto)
    {
        if (dto.Price < 0)
        {
            new Exception("Price is not valid!");
        }

        var product = new Product
        {
            Name = dto.Name,
            Price = dto.Price
        };

        db.Products.Add(product);
        db.SaveChanges();

        return product;
        
    }
    public List<Product> AllProducts()
    {
        var products = db.Products.ToList();

        return products;
    }
}