using System.Net;
using System.Net.Http.Json;
using Shouldly;
using TechnoShop.Models;

namespace Test.Integration.Account;

public class SignOut: TestBase
{
    public SignOut(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
    }

    [Fact(DisplayName = "Success sign out with login user")]
    public async Task SuccessSignOutWithLoginUser()
    {
        //arrange
        await _httpClient.PostAsJsonAsync("Account/:signUp", new SignUpRequest()
        {
            Email = "admin@gmail.com",
            FirstName = "Alex",
            LastName = "Hlushko",
            Password = "PassWord2024$"
        });
        
        await _httpClient.PostAsJsonAsync("Account/:signIn", new SignInRequest()
        {
            Email = "admin@gmail.com",
            Password = "PassWord2024$"   
        });
        
        //act
        var response = await _httpClient.GetAsync("Account/:signOut");
        
        //assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }

    [Fact(DisplayName = "Failed sign out without login user")]
    public async Task FailedSignOutWithoutLoginUser()
    {
        //act
        var response = await _httpClient.GetAsync("Account/:signOut");
        
        //assert
        response.StatusCode.ShouldBe(HttpStatusCode.Unauthorized);
    }
}