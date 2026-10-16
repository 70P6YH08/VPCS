using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Pract1;
using Pract1.PractDbContext;
using Pract1.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlite("Data Source=app.db"));
builder.Services.AddTransient<CarService>();

builder.Services.AddStackExchangeRedisCache(
    options =>
    {
        options.Configuration = "localhost";
        options.InstanceName = "cars_cache";
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello, Word!");

app.MapGet("/car/{id}", async (int id, CarService carService) =>
{
    Car? car = await carService.GetCar(id);
    if (car != null) return JsonSerializer.Serialize(car);
    return "Car not found!!!";
});

app.MapDelete("/car/{id}", async (int id, CarService carService) =>
{
    Car? car = await carService.DeleteUser(id);
    if (car != null) return JsonSerializer.Serialize(car);
    return "Car not found!!!";
});

app.Run();

