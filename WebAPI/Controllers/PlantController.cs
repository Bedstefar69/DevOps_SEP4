using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services.PlantService;

namespace WebAPI.Controllers;


[ApiController]
[Route("[controller]/[action]")]
public class PlantController : ControllerBase
{
    private readonly IPlantService _plantService;

    public PlantController(IPlantService plantService)
    {
        _plantService = plantService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Plant>>> GetPlant()
    {
        return Ok(await _plantService.GetPlant());
    }

    [HttpPost]
    public async Task<ActionResult<List<Plant>>> CreatePlant(string plantname, string? notes)
    {
        return Ok(await _plantService.CreatePlant(plantname, notes));
    }
    
    
}