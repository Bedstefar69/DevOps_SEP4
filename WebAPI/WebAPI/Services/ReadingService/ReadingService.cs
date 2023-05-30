using gRPCWebSocket;
using Microsoft.AspNetCore.Mvc;
using WebAPI.WebAPI.Data;
using WebAPI.WebAPI.Models;
using WebAPI.WebSocket.LogicImpl;

namespace WebAPI.WebAPI.Services.ReadingService;

public class ReadingService : IReadingService
{

    private readonly DataContext _dataContext;

    public ReadingService(DataContext dataContext)
    {
        _dataContext = dataContext;
        getNewestReadings();
    }

    public async Task<ActionResult<List<Reading>>> GetReadings()
    {
        return await _dataContext.Readings.ToListAsync();
    }

    public async Task<ActionResult<List<Reading>>> GetReadingsByName(string name)
    {
        var readings = await _dataContext.Readings.Where(c => c.Plant == name).ToListAsync();

        return readings;
    }


    public async Task<ActionResult<List<Reading>>> GetNewestReading()
    {
        List<Reading> reading = await _dataContext.Readings.ToListAsync();
        List<Reading> readingLast = new List<Reading>();
        readingLast.Add(reading.LastOrDefault());

        return readingLast;
    }

    public async Task<bool> CreateReading(double temperature, double humidity, int co2)
    {
        Console.WriteLine("Creating reading");
        var temp = new Reading()
        {
            Co2 = co2,
            Humidity = humidity,
            Temperature = temperature,
            Plant = "Tomato", // Ændres hvis det er en anden plante der skal tages målinger fra, da alle bytes fra IOT enheden er optaget, kan dette ikke tages som et argument i metoden.
            Timestamp = DateTime.Now
        };

        Console.WriteLine(temp.Timestamp);
        _dataContext.Readings.Add(temp);
        Console.WriteLine("added");
        var created = await _dataContext.SaveChangesAsync();
        Console.WriteLine("saved");
        Console.WriteLine(created > 0);
        return created > 0;
    }

    public async Task getNewestReadings()
    {
        var timer = new PeriodicTimer(TimeSpan.FromMinutes(1));

        while (await timer.WaitForNextTickAsync())
        {
            var response = await SocketService.SocketService.getUpdate();

            if (response.Temp < 999)
            {
                var temp = new Reading()
                {
                    Co2 = response.Ox,
                    Humidity = response.Humid,
                    Temperature = response.Temp,
                    Plant = "Tomato",
                    Timestamp = DateTime.Now
                };

                await _dataContext.Readings.AddAsync(temp);
                await _dataContext.SaveChangesAsync();
                Console.WriteLine("Added");
            }

        }
    }

}