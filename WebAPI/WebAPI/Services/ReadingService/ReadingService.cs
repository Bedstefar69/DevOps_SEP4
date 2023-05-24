using gRPCWebSocket;
using Microsoft.AspNetCore.Mvc;
using WebAPI.WebAPI.Data;
using WebAPI.WebAPI.Models;
using WebAPI.WebSocket.LogicImpl;

namespace WebAPI.WebAPI.Services.ReadingService;

public class ReadingService : IReadingService
{

    private readonly DataContext _dataContext;
    WebSocketLogicImpl webSocketLogicImpl = new WebSocketLogicImpl("http://localhost:4242");

    public ReadingService(DataContext dataContext)
    {
        _dataContext = dataContext;
        Console.WriteLine("HELLO");
        getReadingFromDevice();
        Console.WriteLine("hello?");
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
        var temp = new Reading()
        {
            Co2 = co2,
            Humidity = humidity,
            Temperature = temperature,
            Plant = "Tomato", // Ændres hvis det er en anden plante der skal tages målinger fra, da alle bytes fra IOT enheden er optaget, kan dette ikke tages som et argument i metoden.
            Timestamp = DateTime.Now
        };

        
        _dataContext.Readings.Add(temp);
        var created = await _dataContext.SaveChangesAsync();
        
        return created > 0;

    }

    public async void getReadingFromDevice()
    {
        Console.WriteLine("hi there");
        await webSocketLogicImpl.getConnection();
        var timer = new PeriodicTimer(TimeSpan.FromSeconds(10));

        while (await timer.WaitForNextTickAsync())
        {
            var response = await webSocketLogicImpl.getUpdate(new Update
            {
                Response = "getReadings"
            });

            if (response.Temp > 999.0) //Checker hvis der har været en ny reading - ellers returner den en fallback værdi på 999.9
            {
                await CreateReading(response.Temp, response.Humid, response.Ox);
            }
        }

    }

}