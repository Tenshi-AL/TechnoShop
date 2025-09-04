using System.Net;
using System.Net.Http.Json;
using Shouldly;
using TechnoShop.Models;

namespace Test.Integration.Account;

public class SignUp: TestBase
{
    public SignUp(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
        
    }

    [Fact(DisplayName = "Success registration with valid data")]
    public async Task SuccessRegistrationWithValidData()
    {
        //arrange
        var signUpRequest = new SignUpRequest()
        {
            Email = "admin@gmail.com",
            FirstName = "Alex",
            LastName = "Hlushko",
            Password = "PassWord2024$"
        };
        
        //act
        var response = await _httpClient.PostAsJsonAsync("Account/:signUp", signUpRequest);

        //assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }
    
    [Theory(DisplayName = "Failed registration with invalid data")]
    [InlineData("", "Alex", "Ivanov", "Password123!")]                        // Empty email
    [InlineData("not-an-email", "Alex", "Ivanov", "Password123!")]            // Invalid email format
    [InlineData("user@mail.com", "", "Ivanov", "Password123!")]               // Empty first name
    [InlineData("user@mail.com", "Alex", "", "Password123!")]                 // Empty last name
    [InlineData("user@mail.com", "Alex", "Ivanov", "")]                       // Empty password
    [InlineData("user@mail.com", "Alex", "Ivanov", "123")]                    // Too short password
    [InlineData("user@mail.com", "Alex", "Ivanov", "password")]               // Password without uppercase, digits, special chars
    [InlineData("user@mail.com", "Alex", "Ivanov", "PASSWORD123")]            // Password without lowercase letters
    [InlineData("user@mail.com", "Alex", "Ivanov", "pass<sc>word123!")]       // Password with potential XSS
    [InlineData(null, "Alex", "Ivanov", "Password123!")]                      // Null email
    [InlineData("user@mail.com", null, "Ivanov", "Password123!")]             // Null first name
    [InlineData("user@mail.com", "Alex", null, "Password123!")]               // Null last name
    [InlineData("user@mail.com", "Alex", "Ivanov", null)]                     // Null password
    [InlineData("verylongemailaddress_morethan255characters_"
               + "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"
               + "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"
               + "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"
               + "@mail.com", "Alex", "Ivanov", "Password123!")]                    // Email exceeding max length
    [InlineData("user@mail.com", "AlexWithVeryLongNameExceedingMaxLimit"
               + "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 
               "Ivanov", "Password123!")]                                                   // First name exceeding max length
    [InlineData("user@mail.com", "Alex", 
               "IvanovWithVeryLongLastNameExceedingMaxLimit"
               + "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 
               "Password123!")]   
    public async Task FailedRegistrationWithInvalidData(string email, string firstName, string lastName, string password)
    {
        //arrange
        var signUpRequest = new SignUpRequest()
        {
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            Password = password
        };
        
        //act
        var response = await _httpClient.PostAsJsonAsync("Account/:signUp", signUpRequest);

        //assert
        response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
    }

    [Fact(DisplayName = "Failed registration with duplicate email")]
    public async Task FailedRegistrationWithDuplicateEmail()
    {
        //arrange
        var firstUser = new SignUpRequest()
        {
            Email = "first@gmail.com",
            FirstName = "Alex",
            LastName = "Hlushko",
            Password = "PassWord2024$"
        };
        await _httpClient.PostAsJsonAsync("Account/:signUp", firstUser);
        //act
        var response = await _httpClient.PostAsJsonAsync("Account/:signUp", new SignUpRequest()
        {
            Email = "first@gmail.com",
            FirstName = "Victor",
            LastName = "Victorenko",
            Password = "PassWord2024$"
        });

        //assert
        response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
    }
}