using System;
using Marketplace.Catalog.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Catalog.Api.Controllers;


[ApiController]
[Route("api/v1/[controller]")]
public class ProductController: ControllerBase
{
    public ProductController()
    {
        
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
     return null;
    }

    
    [HttpGet]
    [Route("getBy-id")]
    public async Task<IActionResult> GetById ([FromQuery] Guid id)
    {
      return null;
    }

    
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] Product product)
    {
      return null;
    }

    
    [HttpPatch]
    public async Task<IActionResult> UpdateProdutc([FromBody] Product product)
    {
      return null;
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteProduct([FromQuery] Guid id)
    {
      return null;
    }

}