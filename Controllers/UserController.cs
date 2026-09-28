using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/user")]
public class UserController: ControllerBase
{

    public readonly AppDbContext db; 
    public UserController(AppDbContext db)
    {
        this.db = db;
    }
    [HttpGet]
    [Authorize]
    public IActionResult MyAccount(HttpContext context)
    {
        var claims = context.User.Claims;
        var id = claims.FirstOrDefault(n => n.Type == "sub")?.Value; // understand this better 
        var MyData = db.Users.Find(id);

        //make a dto to hide sensitive user data 
        // testing github
        return Ok(MyData); 
    }
    
    [HttpPost]
    [Authorize]
    public IActionResult EditUserInfo()
    {
        return Ok();
    }


}