using EmployeeManagement.API.Data;
using EmployeeManagement.API.GraphQL; // Add this if Query is in GraphQL folder
using Microsoft.EntityFrameworkCore;
using Notification;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();
builder.Services.AddGrpcClient<NotificationService.NotificationServiceClient>(options =>
{
    options.Address = new Uri("https://localhost:7155");
}); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Map REST Controllers
app.MapControllers();

// Map GraphQL Endpoint
app.MapGraphQL();


// You can keep or remove this WeatherForecast endpoint
app.MapGet("/weatherforecast", () =>
{
    var summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild",
        "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast(
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();

    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}