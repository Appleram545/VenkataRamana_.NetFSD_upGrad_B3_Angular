using Microsoft.EntityFrameworkCore;
using ContactManage.Models;
using ContactManage.Repository;

var builder = WebApplication.CreateBuilder(args); // ✅ MUST BE FIRST

builder.Services.AddControllersWithViews();

// ✅ Add services
builder.Services.AddControllers();
builder.Services.AddScoped<IContactRepository, ContactRepository>();

// ✅ DB Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

// ✅ Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔥 MIDDLEWARE PIPELINE

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ✅ HTTPS
app.UseHttpsRedirection();

// ✅ CORS
app.UseCors("AllowAngular");

// ✅ Authorization
app.UseAuthorization();

// ✅ Controllers
app.MapControllers();

app.Run();