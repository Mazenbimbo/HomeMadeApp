using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users{get;set;}
    public DbSet<Product> Products{set;get;}
    public DbSet<Seller> Sellers{set;get;}
}