using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Services.PlantService;

public interface IPlantService
{
    public Task<ActionResult<List<Plant>>> GetPlant();
    public Task<ActionResult<List<Plant>>> CreatePlant(string plantname, string? notes);
}