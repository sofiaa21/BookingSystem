namespace WebAPI.Controllers;

using Logic;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.DTOs;

[ApiController]
[Route("[controller]")]
public class ResourceController:ControllerBase
{
    private readonly IResourceLogic resourceLogic;

    public ResourceController(IResourceLogic resourceLogic)
    {
        this.resourceLogic = resourceLogic;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Resource>>> GetAsync([FromQuery] string? name, [FromQuery] int? quantity)
    {
        try
        {
            ResourceDto resource = new(name, quantity);
            var resources = await resourceLogic.GetAsync(resource);
            return Ok(resources);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ResourceGetByIdDto>> GetById([FromRoute] int id)
    {
        try
        {
            ResourceGetByIdDto result = await resourceLogic.GetByIdAsync(id);
            return Ok(result);
        }
        catch ( Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500,e.Message);
        }
        
    }
}

