using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
[ApiController]
[Route("/auth")]
public class AuthenticationController : ControllerBase
{
    public AuthenticationService authenticationService;
    public AppDbContext db;

    public AuthenticationController(AuthenticationService authenticationService,AppDbContext db)
    {
        this.authenticationService = authenticationService;
        this.db = db;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginCreds request)
    {
        string email = request.email;
        string password = request.password;

        var user = db.Users.FirstOrDefault(u => u.Email == email);

        if(user == null)
        {
            return Unauthorized("Wrong Email or Password!");
        }
        if(user.Password != password)
        {
            return Unauthorized("Wrong Email or Password!");
        }
        var token = authenticationService.CreateToken(user.ID,user.Name,user.Role);
        return Ok(new {token = token});
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public IActionResult Register(User user)
    {
        if (user == null)
        {
            return BadRequest();
        }

        if (string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password))
        {
            return BadRequest("Name, email and password are required.");
        }
        try
        {
            authenticationService.Register(user);
            return Ok(new { message = "User registered successfully" });
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}