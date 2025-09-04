using System.Net;
using System.Net.Http.Json;
using Shouldly;
using TechnoShop.Models;

namespace Test.Integration.Account;

public class SignIn: TestBase
{
    public SignIn(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
        
    }

    [Theory(DisplayName = "Success login with valid data")]
    [InlineData("admin@gmail.com", "PassWord2024$")]  
    public async Task SuccessLoginWithValidData(string email, string password)
    {
        //act
        var signUpRequest = new SignUpRequest()
        {
            Email = email,
            FirstName = "Alex",
            LastName = "Hlushko",
            Password = password,
        };
        await _httpClient.PostAsJsonAsync("Account/:signUp", signUpRequest);
        
        //arrange
        var response = await _httpClient.PostAsJsonAsync("Account/:signIn", new SignInRequest()
        {
            Email = email,
            Password = password
        });
        
        //assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }

    [Fact(DisplayName = "Failed login with non registered user")]
    public async Task FailedLoginWithNonRegisteredUser()
    {
        //act
        var request = new SignInRequest()
        {
            Email = "nonregistereduser@gmail.com",
            Password = "PassWord2024$"
        };
        
        //arrange
        var response = await _httpClient.PostAsJsonAsync("Account/:signIn", request);
        
        //assert
        response.StatusCode.ShouldBe(HttpStatusCode.Unauthorized);
    }

    [Theory(DisplayName = "Failed login with invalid data")]
    [InlineData("", "Password123!")] // Empty email
    [InlineData("usermail.com", "Password123!")] // Invalid email format (missing @)
    [InlineData("user@mail.com", "")] // Empty password
    [InlineData("user@mail.com", "WrongPass")] // Wrong password
    [InlineData(null, "Password123!")] // Null email
    [InlineData("user@mail.com", null)] // Null password
    [InlineData("' OR 1=1 --", "any")] // SQL injection attempt in email
    [InlineData("<script>alert(1)</script>", "Password123!")] // XSS attempt in email
    [InlineData("verylongemailaddress_morethan255characters_"
                + "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"
                + "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"
                + "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"
                + "@mail.com", "Password123!")] // Email exceeding max length
    public async Task FailedLoginWithInvalidData(string email, string password)
    {
        //arrange
        var request = new SignInRequest()
        {
            Email = email,
            Password = password
        };
        
        //act
        var response = await _httpClient.PostAsJsonAsync("Account/:signIn", request);
        
        //assert
        response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
    }
}