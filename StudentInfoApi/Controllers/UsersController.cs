﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentInfoAPI.Entities;
using StudentInfoAPI.ResourceModels;
using StudentInfoAPI.Services;

namespace StudentInfoAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly JwtService _jwtService;
    private readonly ApiKeyService _apiKeyService;

    public UsersController(UserManager<IdentityUser> userManager, JwtService jwtService, ApiKeyService apiKeyService)
    {
        _userManager = userManager;
        _jwtService = jwtService;
        _apiKeyService = apiKeyService;
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateAccount(User user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _userManager.CreateAsync(new IdentityUser()
        {
            UserName = user.UserName,
            Email = user.Email,
        }, 
        user.Password);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        user.Password = null;
        return CreatedAtAction(nameof(GetUser), new User { UserName = user.UserName}, user);
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<User>> GetUser(string username)
    {
        IdentityUser user = await _userManager.FindByNameAsync(username);

        if(user == null)
        {
            return NotFound();
        }
        return new User
        {
            UserName = user.UserName,
            Email = user.Email
        };
    }

    [HttpPost("BearerToken")]
    public async Task<ActionResult<AuthenticationResponse>> CreateBearerToken(AuthenticationRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Bad Credentials");
        }

        var user = await _userManager.FindByNameAsync(request.UserName);

        if (user == null)
        {
            return BadRequest("Bad Credentials");
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

        if (!isPasswordValid)
        {
            return BadRequest("Bad Credentials");
        }


        var token = _jwtService.CreateToken(user);

        return Ok(token);
    }

    [HttpPost("ApiKey")]
    public async Task<ActionResult> CreateApiKey(AuthenticationRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _userManager.FindByNameAsync(request.UserName);

        if (user == null)
        {
            return BadRequest("Bad credentials");
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

        if (!isPasswordValid)
        {
            return BadRequest("Bad credentials");
        }

        var token = _apiKeyService.CreateApiKey(user);

        return Ok(token);
    }
}
