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
    
}