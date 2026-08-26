var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddScoped<DoHabits>();
builder.Services.AddScoped<IEngine,FuelEngine>();


var app = builder.Build();

app.MapControllers();

app.Run();
