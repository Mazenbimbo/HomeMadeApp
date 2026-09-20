using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.Intrinsics.X86;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddScoped<DoHabits>();
builder.Services.AddScoped<IEngine,FuelEngine>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=data.db"));
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
{
   ValidateAudience =true,
   ValidateIssuer =true,
   ValidateLifetime =true,
   ValidateIssuerSigningKey=true,

   ValidIssuer = "Mazen's Server",
   ValidAudience = "Mazen's website visiters",
   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my own password"))
   
});
builder.Services.AddAuthorization();


var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
