using ContactService.Data;
using ContactService.Repositories;
using ContactService.Services;
using Microsoft.EntityFrameworkCore;
using ContactService.Models;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddControllers();
builder.Services.AddDbContext<ContactDbContext>(options =>
    options.UseInMemoryDatabase("ContactDB"));


builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactService.Services.ContactService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");



app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ContactDbContext>();

    if (!context.Contacts.Any())
    {
        context.Contacts.AddRange(
            new Contact
            {
                Name = "Ram",
                Email = "ram@gmail.com",
                Phone = "7330809975",
                CategoryId = 1
            },
            new Contact
            {
                Name = "Sita",
                Email = "sita@gmail.com",
                Phone = "7834537282",
                CategoryId = 2
            }
        );

        context.SaveChanges();
    }
}



app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
