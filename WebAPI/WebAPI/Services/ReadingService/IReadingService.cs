using Microsoft.AspNetCore.Mvc;
using WebAPI.WebAPI.Models;

namespace WebAPI.WebAPI.Services.ReadingService;

public interface IReadingService
{
    public Task<ActionResult<List<Reading>>> GetReadings();
    public Task<ActionResult<List<Reading>>> GetNewestReading();

    public Task<ActionResult<List<Reading>>> CreateReading(double temperature, double humidity, int co2);
    
    public Task<ActionResult<List<Reading>>> GetReadingsByName(string name);
    
}