using Domain.Interfaces;
using FluentValidation.AspNetCore;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Persistence;
using TechnoShop;
using TechnoShop.DTO;
using TechnoShop.Helpers;
using TechnoShop.ServicesExtensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers(options =>
    {
        options.InputFormatters.Insert(0, MyJPIF.GetJsonPatchInputFormatter());
    })
    .AddFluentValidation(p => p.RegisterValidatorsFromAssembly(typeof(GpuWriteDtoValidator).Assembly));

builder.Services.AddOpenApi();

builder.Services.AddDbContext<TechnoShopContext>(p =>
    p.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

builder.Services.SwaggerConfigure();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IRAMService, RAMService>();
builder.Services.AddScoped<ISSDService, SSDService>();
builder.Services.AddScoped<IPSUService, PSUService>();
builder.Services.AddScoped<IMotherboardService, MotherboardService>();
builder.Services.AddScoped<IGpuService, GpuService>();
builder.Services.AddScoped<IProcessorService, ProcessorService>();

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

