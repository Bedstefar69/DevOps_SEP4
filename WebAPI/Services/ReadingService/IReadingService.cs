using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Services.ReadingService;

public interface IReadingService
{
    public Task<ActionResult<List<Reading>>> GetReadings();
    public Task<ActionResult<List<Reading>>> GetNewestReading();
}