using Marketplace.Catalog.Application.interfaces;
using Marketplace.Catalog.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Catalog.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthController: ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ILogger<AuthController> _logger;
    public AuthController(IAuthService authService, ILogger<AuthController> logger)
    {
        _authService = authService;
        _logger = logger;
    
    }

    [HttpPost ("login")]
    public async Task<IActionResult> Login([FromQuery] LoginRequest loginRequest)
    {
        try
        {
             if (!loginRequest.IsValid())
            {
                return BadRequest(new { message = "Invalid request data" });
            }
                
            var response = await _authService.AuthenticateAsync(loginRequest);
                
            if (response == null)
            {
                _logger.LogWarning("Failed login attempt for user: {RequestUsername}", loginRequest.Email);
                return Unauthorized(new { message = "Invalid credentials" });
            }
                
            _logger.LogInformation("User {RequestUsername} logged in successfully", loginRequest.Email);
            return Ok(response);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, "Error during login");
            return StatusCode(500, new { message = "Internal server error" });
        }
    }
}