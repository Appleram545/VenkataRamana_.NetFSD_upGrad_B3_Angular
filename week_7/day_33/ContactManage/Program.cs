using ContactManage.Models;
using ContactManage.Repository;
using Microsoft.EntityFrameworkCore; // ⭐ IMPORTANT

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ✅ FIX HERE
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IContactRepository, ContactRepository>();

var app = builder.Build();