using Microsoft.EntityFrameworkCore;

public class CartService
{
    public readonly IHttpContextAccessor httpContextAccessor;
    public readonly AppDbContext db;
    public CartService(AppDbContext db,IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
        this.db = db;
    }

    public void AddToCart(Product product)
    {
        var user = httpContextAccessor.HttpContext.User;

        if (product == null)
        {
            throw new Exception(); // still don't understand this 
        }

        var p = new CartItem();
        p.CustomerId = int.Parse(user.FindFirst("sub")?.Value);
        p.Product = product;
        p.ProductId = product.Id;
        p.Amount = 1;

        db.CartItems.Add(p);
        db.SaveChanges();

    }

    public List<CartItem> GetCartItems()
    {
        var user = httpContextAccessor.HttpContext.User;
        var id = int.Parse(user.FindFirst("sub")?.Value);
        var cartItems = db.CartItems.Where(n=>n.CustomerId == id).ToList(); // what if no items 
        return cartItems;

    }
}