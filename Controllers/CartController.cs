using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/cart")]
public class CartController:ControllerBase
{
    public readonly CartService cart;

    public CartController(CartService cart)
    {
        this.cart = cart;
    }

    [HttpPost]
    [Authorize]
    public IActionResult AddToCart(Product product)
    {
        cart.AddToCart(product);
        return Created();
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetCartItems()
    {
        var cartItems = cart.GetCartItems();
        return Ok(cartItems);
    }
}