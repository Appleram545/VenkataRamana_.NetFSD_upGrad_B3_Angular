using ContactManagement2.Interfaces;
using ContactManagement2.Repositories;
using ContactManagement2.Services;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // ✅ requires Swashbuckle

builder.Services.AddSingleton<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactService>();

var app = builder.Build();

// Middleware
app.UseSwagger();      
app.UseSwaggerUI();

app.MapControllers();

app.Run();