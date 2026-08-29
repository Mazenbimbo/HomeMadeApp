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
    public IActionResult CreateProduct(CreateProductDto dto)
    {
        var p = productService.CreateProduct(dto); 
        return Ok("Created");
    }
}