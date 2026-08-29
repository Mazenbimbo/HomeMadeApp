using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddScoped<DoHabits>();
builder.Services.AddScoped<IEngine,FuelEngine>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=data.db"));


var app = builder.Build();

app.MapControllers();

app.Run();
