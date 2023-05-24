using Microsoft.AspNetCore.Mvc;
using WebAPI.WebAPI.Models;
using WebAPI.WebAPI.Services.ReadingService;

namespace WebAPI.WebAPI.Controllers;


[ApiController]
[Route("[controller]/[action]")]
public class ReadingController : ControllerBase
{
    private readonly IReadingService _readingService;

    public ReadingController(IReadingService readingService)
    {
        _readingService = readingService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Reading>>> GetReadings()
    {
        return Ok(_readingService.GetReadings().Result);
    }

    [HttpGet]
    public async Task<ActionResult<List<Reading>>> GetReadingsByName(string name)
    {
        return Ok(await _readingService.GetReadingsByName(name));
    }
    
    [HttpGet] 
    public async Task<ActionResult<List<Reading>>> GetNewestReading()
    {
        return Ok(await _readingService.GetNewestReading());
    }

    [HttpPost]
    public async Task<ActionResult<List<Reading>>> CreateReading(double temperature, double humidity, int co2)
    {
        return Ok(await _readingService.CreateReading(temperature, humidity, co2));
    }
    
    
}