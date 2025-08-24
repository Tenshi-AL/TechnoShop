using Domain.Interfaces;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Persistence;
using TechnoShop.ServicesExtensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<TechnoShopContext>(p =>
    p.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
builder.Services.SwaggerConfigure();
builder.Services.AddScoped<IGpuService, GpuService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

