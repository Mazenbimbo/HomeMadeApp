using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

public class AuthenticationService
{
    public AppDbContext db;
    public AuthenticationService(AppDbContext db)
    {
        this.db = db;
    }
    public string CreateToken(int id, string name,User.roles role)
    {

        var claims = new []
        {
            new Claim("sub",id.ToString()),
            new Claim("Name",name),
            new Claim("Role",role.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my own password"));

        var credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "Mazen's Server",
            audience : "Mazen's website visiters",
            claims : claims,
            signingCredentials : credentials,
            expires : DateTime.Now.AddDays(7)

        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);


        return jwt;
    }

    public void Register(User user)
    {

        // check if it already exists 

        var u = new User
        {
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
            Role = User.roles.Customer
        };

        db.Users.Add(u);
        db.SaveChanges();
    }
}