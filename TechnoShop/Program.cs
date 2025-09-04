using Domain.Interfaces;
using Domain.Models;
using FluentValidation.AspNetCore;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Minio;
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

builder.Services.AddMinio(configureClient => configureClient
    .WithEndpoint(configuration["MinIOCredentials:url"])
    .WithCredentials(configuration["MinIOCredentials:accessKey"], configuration["MinIOCredentials:secretKey"])
    .WithSSL(false)
    .Build());

builder.Services.AddDbContext<TechnoShopContext>(p =>
    p.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpContextAccessor();
builder.Services.SwaggerConfigure();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IRAMService, RAMService>();
builder.Services.AddScoped<ISSDService, SSDService>();
builder.Services.AddScoped<IPSUService, PSUService>();
builder.Services.AddScoped<IMotherboardService, MotherboardService>();
builder.Services.AddScoped<IGpuService, GpuService>();
builder.Services.AddScoped<IProcessorService, ProcessorService>();
builder.Services.AddScoped<IBlobStorageService, BlobStorageService>();


builder.Services.AddIdentity<User, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<TechnoShopContext>()
    .AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(opt =>
{
    //prevent redirection to login endpoint when user is not authorized
    opt.Events.OnRedirectToLogin = ctx =>
    {
        ctx.Response.StatusCode = StatusCodes.Status401Unauthorized;
        return Task.CompletedTask;
    };

    opt.Events.OnRedirectToAccessDenied = ctx =>
    {
        ctx.Response.StatusCode = StatusCodes.Status403Forbidden;
        return Task.CompletedTask;
    };
});

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

public partial class Program {}