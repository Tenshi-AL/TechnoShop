using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace Test.Integration;

public class TestBase: IClassFixture<IntegrationTestWebAppFactory>
{
    protected readonly IntegrationTestWebAppFactory _integrationTestWebAppFactory;
    protected readonly HttpClient _httpClient;
    protected readonly TechnoShopContext _sen4Context;
    protected readonly IServiceScope _serviceScope;
    protected readonly UserManager<User> _userManager;
    
    public TestBase(IntegrationTestWebAppFactory integrationTestWebAppFactory)
    {
        _integrationTestWebAppFactory = integrationTestWebAppFactory;
        _httpClient = _integrationTestWebAppFactory.CreateClient();
        _serviceScope = _integrationTestWebAppFactory.Services.CreateScope();
        _userManager = _serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
        _sen4Context = _serviceScope.ServiceProvider.GetRequiredService<TechnoShopContext>();
    }
}