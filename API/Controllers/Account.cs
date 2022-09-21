using API.DTOs;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class Account : BaseApiController
{
    private readonly IConfiguration _config;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ITokenService _tokenService;
    public Account(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService, IConfiguration config)
    {
        _tokenService = tokenService;
        _signInManager = signInManager;
        _userManager = userManager;
        _config = config;

    }

    // Register
    [HttpPost("Register")]
    public async Task<ActionResult<UserDto>> Register(RegisterLoginDto val)
    {
        if (await UserExists(val.Email)) return BadRequest("User Already Exists");

        var user = new User
        {
            UserName = val.Email.ToLower(),
            Email = val.Email.ToLower()
        };

        var result = await _userManager.CreateAsync(user, val.Password);

        if (!result.Succeeded) return BadRequest(result.Errors);

        var roleResult = await _userManager.AddToRoleAsync(user, val.Role);

        if (!roleResult.Succeeded) return BadRequest(result.Errors);

        return new UserDto
        {
            Email = user.Email,
            Token = await _tokenService.CreateToken(user)
        };
    }

    // Login
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(RegisterLoginDto val)
    {
        var user = await _userManager.Users.SingleOrDefaultAsync(u => u.UserName == val.Email.ToLower());

        if (user is null) return Unauthorized("Invalid user");

        var result = await _signInManager.CheckPasswordSignInAsync(user, val.Password, false);

        if (!result.Succeeded) return Unauthorized();

        return new UserDto
        {
            Email = user.Email,
            Token = await _tokenService.CreateToken(user)
        };
    }

    // Check if user exists
    private async Task<bool> UserExists(string username)
    {
        return await _userManager.Users.AnyAsync(u => u.UserName == username.ToLower());
    }
}
