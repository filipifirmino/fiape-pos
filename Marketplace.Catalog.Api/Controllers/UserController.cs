using Marketplace.Catalog.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Catalog.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    public UserController()
    {
        
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        return null;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUser()
    {
        return null;
    }

    [HttpGet]
    [Route("getBy-id")]
    public async Task<IActionResult> GetUserById([FromQuery] Guid id)
    {
        return null;
    }






}