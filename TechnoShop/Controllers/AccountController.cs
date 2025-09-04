using System.Security.Claims;
using System.Transactions;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechnoShop.Models;

namespace TechnoShop.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController(SignInManager<User> signInManager, 
    UserManager<User> userManager,
    IHttpContextAccessor httpContextAccessor): ControllerBase
{
    /// <summary>
    /// Sign up user in system.
    /// </summary>
    /// <param name="request">Sign up request.</param>
    /// <returns>HTTP result status code</returns>
    [HttpPost(":signUp")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SignUp([FromBody]SignUpRequest request)
    {
        var user = new User()
        {
            UserName = request.Email,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        var createResult = await userManager.CreateAsync(user, request.Password);
        if (!createResult.Succeeded) return BadRequest(createResult.Errors);
        
        var addToRoleResult = await userManager.AddToRoleAsync(user, "Client");
        if (!addToRoleResult.Succeeded)
        {
            await userManager.DeleteAsync(user);
            return BadRequest(addToRoleResult.Errors);
        }
        
        return Ok();
    }
    
    /// <summary>
    /// Sign in user in system.
    /// </summary>
    /// <param name="request">Sign in request.</param>
    /// <returns>HTTP result status code</returns>
    [HttpPost(":signIn")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> SignIn(SignInRequest request)
    {
        var result = await signInManager.PasswordSignInAsync(request.Email, request.Password, true, false);
        return result.Succeeded ? Ok() : Unauthorized();
    }

    [Authorize]
    [HttpGet(":signOut")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> SignOut()
    {
        await signInManager.SignOutAsync();
        return Ok();
    }
    
    /// <summary>
    /// Change user password.
    /// </summary>
    /// <param name="request">Change password request</param>
    /// <returns>HTTP result status code</returns>
    [Authorize]
    [HttpPost(":changePassword")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
    {
        var currentUser = httpContextAccessor?.HttpContext?.User;
        if (currentUser is null) return Unauthorized();
        var email = currentUser.FindFirst(ClaimTypes.Email)?.Value;
        if (email is null || email != request.Email) return Forbid();
        
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user is null) return NotFound();

        var result = await userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
        return result.Succeeded ? Ok() : BadRequest(result.Errors);
    }
    
}