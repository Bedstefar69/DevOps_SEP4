using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services.ReadingService;

namespace WebAPI.Controllers;


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
    public async Task<ActionResult<List<Reading>>> GetNewestReading()
    {
        return Ok(await _readingService.GetNewestReading());
    }

    [HttpPost]
    public async Task<ActionResult<List<Reading>>> CreateReading(int temperature, int humidity, int co2)
    {
        return Ok(await _readingService.CreateReading(temperature, humidity, co2));
    }
    
    
}