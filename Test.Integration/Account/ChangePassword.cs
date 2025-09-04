using System.Net;
using System.Net.Http.Json;
using Shouldly;
using TechnoShop.Models;

namespace Test.Integration.Account;

public class ChangePassword: TestBase
{
    public ChangePassword(IntegrationTestWebAppFactory integrationTestWebAppFactory) : base(integrationTestWebAppFactory)
    {
    }
    
    [Fact(DisplayName = "Success change password with valid data")]
    public async Task SuccessChangePasswordWithValidData()
    {
        // Arrange
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
        
        var changePasswordRequest = new ChangePasswordRequest()
        {
            Email = "admin@gmail.com",
            CurrentPassword = "PassWord2024$",
            NewPassword = "NewCoolWord2024$"
        };

        // Act
        var response = await _httpClient.PostAsJsonAsync("Account/:changePassword", changePasswordRequest);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }

    [Theory(DisplayName = "Failed change password with invalid data")]
    [InlineData("", "OldPassword123!", "NewPassword123!")] // Empty email
    [InlineData("user@gmail.com", "", "NewPassword123!")] // Empty current password
    [InlineData("user@gmail.com", "OldPassword123!", "")] // Empty new password
    [InlineData("user@gmail.com", "WrongPassword!", "NewPassword123!")] // Wrong current password
    [InlineData("user@gmail.com", "OldPassword123!", "OldPassword123!")] // New password same as old
    [InlineData("user@gmail.com", "OldPassword123!", "123")] // New password too short
    [InlineData("user@gmail.com", "OldPassword123!",
        "newpassword123")] // New password missing uppercase / special chars
    [InlineData(null, "OldPassword123!", "NewPassword123!")] // Null email
    [InlineData("user@gmail.com", null, "NewPassword123!")] // Null current password
    [InlineData("user@gmail.com", "OldPassword123!", null)] // Null new password
    public async Task FailedChangePasswordWithInvalidData(string email, string currentPassword, string newPassword)
    {
        // Arrange
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
        
        var changePasswordRequest = new ChangePasswordRequest()
        {
            Email = email,
            CurrentPassword = currentPassword,
            NewPassword = newPassword
        };

        // Act
        var response = await _httpClient.PostAsJsonAsync("Account/:changePassword", changePasswordRequest);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
    }
    
    [Fact(DisplayName = "Failed change password when user not authenticated")]
    public async Task FailedChangePasswordWhenUserNotAuthenticated()
    {
        // Arrange
        var changePasswordRequest = new ChangePasswordRequest()
        {
            Email = "user@gmail.com",
            CurrentPassword = "OldPassword123!",
            NewPassword = "NewPassword123!"
        };

        // Act
        var response = await _httpClient.PostAsJsonAsync("Account/:changePassword", changePasswordRequest);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.Unauthorized);
    }
    
    [Fact(DisplayName = "Failed change password when email does not match current user")]
    public async Task FailedChangePasswordWithEmailMismatch()
    {
        // Arrange
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
        
        var changePasswordRequest = new ChangePasswordRequest()
        {
            Email = "otheruser@gmail.com",
            CurrentPassword = "OldPassword123!",
            NewPassword = "NewPassword123!"
        };

        // Act
        var response = await _httpClient.PostAsJsonAsync("Account/:changePassword", changePasswordRequest);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.Forbidden);
    }
}