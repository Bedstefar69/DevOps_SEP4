using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Services.ReadingService;

public class ReadingService : IReadingService
{

    private readonly DataContext _dataContext;

    public ReadingService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ActionResult<List<Reading>>> GetReadings()
    {
        return await _dataContext.Readings.ToListAsync();
    }

    public async Task<ActionResult<List<Reading>>> GetNewestReading()
    {
        List<Reading> reading = await _dataContext.Readings.ToListAsync();
        List<Reading> readingLast = new List<Reading>();
        readingLast.Add(reading.LastOrDefault());
        
        return readingLast;
    }
}