using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    public readonly ProductService productService;
    public ProductController(ProductService productService){
        this.productService = productService;
    }

    [HttpPost]
    public IActionResult CreateProduct(Product product)
    {
        var p = productService.CreateProduct(product); 
        return Ok(p);
    }
    [HttpGet("all")]
    public IActionResult AllProducts()
    { 
        var products = productService.AllProducts();
        return Ok(products);
    }
}