using CategoryService.Data;
using CategoryService.Repositories;
using CategoryService.Services;
using Microsoft.EntityFrameworkCore;
using CategoryService.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// DB
builder.Services.AddDbContext<CategoryDbContext>(options =>
    options.UseInMemoryDatabase("CategoryDB"));

// DI
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService.Services.CategoryService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger UI
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CategoryDbContext>();

    if (!context.Categories.Any())
    {
        context.Categories.AddRange(
            new Category
            {
                CategoryName = "Friends",
                Description = "Personal contacts"
            },
            new Category
            {
                CategoryName = "Work",
                Description = "Office contacts"
            }
        );

        context.SaveChanges();
    }
}



app.Run();