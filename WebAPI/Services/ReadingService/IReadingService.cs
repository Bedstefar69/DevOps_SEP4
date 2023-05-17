using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Services.ReadingService;

public interface IReadingService
{
    public Task<ActionResult<List<Reading>>> GetReadings();
    public Task<ActionResult<List<Reading>>> GetNewestReading();

    public Task<ActionResult<List<Reading>>> CreateReading(int temperature, int humidity, int co2);
}