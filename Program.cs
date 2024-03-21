using Microsoft.EntityFrameworkCore;
using Sorteo.Application.Services;
using Sorteo.Domain.Interfaces;
using Sorteo.Infrastructure.Data;
using Sorteo.Infrastructure.Data.Repositories;
using Sorteo.Infrastructure.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configurar la conexión de base de datos
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar ApplicationDbContext en el contenedor de inyección de dependencias
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Registrar servicios de aplicación y de infraestructura
//builder.Services.AddScoped<ApiKeyService>();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<AsignacionService>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IAsignacionRepository, AsignacionRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseMiddleware<ApiKeyMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
