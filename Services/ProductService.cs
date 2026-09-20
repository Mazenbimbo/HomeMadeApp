public class ProductService
{
    public readonly AppDbContext db;
    public readonly IHttpContextAccessor httpContextAccessor;

    public ProductService(AppDbContext db,IHttpContextAccessor httpContextAccessor)
    {
        this.db = db;
        this.httpContextAccessor = httpContextAccessor;
    }

    public Product CreateProduct(Product product)
    {
        var user = httpContextAccessor.HttpContext.User;

        if(product.Name == null || product.Description == null || product.Category == null )
        {
            throw new Exception("Please provide name, description and category");
        }
        if (product.Price < 0)
        {
            throw new Exception("Price is not valid!");
        }

        var id = user.FindFirst("sub")?.Value;

        if (id == null)
        {
            throw new Exception("ID error!");
        }

        var seller = db.Sellers.Find(id);

        var p = new Product
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Category = product.Category,
            Images = product.Images,
            Seller = seller
        };

        db.Products.Add(p);
        db.SaveChanges();

        return product;
        
    }
    public List<Product> AllProducts()
    {
        var products = db.Products.ToList();

        return products;
    }
}