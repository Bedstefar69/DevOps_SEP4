using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Services.PlantService;

public class PlantService : IPlantService
{
    private readonly DataContext _dataContext;

    public PlantService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ActionResult<List<Plant>>> GetPlant()
    {
        return await _dataContext.Plants.ToListAsync();
    }

    public async Task<ActionResult<List<Plant>>> CreatePlant(string plantname, string? notes)
    {
        var plant = new Plant()
        {
            Name = plantname,
            Notes = notes
        };

        _dataContext.Plants.Add(plant);
        await _dataContext.SaveChangesAsync();

        return _dataContext.Plants.ToList();

    }
}