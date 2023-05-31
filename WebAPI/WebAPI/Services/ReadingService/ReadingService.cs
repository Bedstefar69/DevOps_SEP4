using gRPCWebSocket;
using Microsoft.AspNetCore.Mvc;
using WebAPI.WebAPI.Data;
using WebAPI.WebAPI.Models;
using WebAPI.WebSocket.LogicImpl;

namespace WebAPI.WebAPI.Services.ReadingService;

public class ReadingService : IReadingService
{

    private readonly DataContext _dataContext;
    private Boolean isChecking;

    public ReadingService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ActionResult<List<Reading>>> GetReadings()
    {
        getNewestReadingFromJava();
        return await _dataContext.Readings.ToListAsync();
    }

    public async Task<ActionResult<List<Reading>>> GetReadingsByName(string name)
    {
        getNewestReadingFromJava();
        var readings = await _dataContext.Readings.Where(c => c.Plant == name).ToListAsync();

        return readings;
    }


    public async Task<ActionResult<List<Reading>>> GetNewestReading()
    {
        getNewestReadingFromJava();
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
        await _dataContext.Readings.AddAsync(temp);
        var result = _dataContext.SaveChangesAsync().Result;
        Console.WriteLine("Reading created");
        return result > 0;
    }   

    private async void getNewestReadingFromJava()
    {
        
        var response = await SocketService.SocketService.getUpdate();

        if (response.Temp < 999)
        {
            Console.WriteLine("Reading recieved");
            await CreateReading(response.Temp, response.Humid, response.Ox);
            
        }

        /*
        var timer = new PeriodicTimer(TimeSpan.FromSeconds(10));
        

        while (await timer.WaitForNextTickAsync())
        {
            var response = await SocketService.SocketService.getUpdate();

            if (response.Temp < 999)
            {
                /*var temp = new Reading()
                {
                    Co2 = response.Ox,
                    Humidity = response.Humid,
                    Temperature = response.Temp,
                    Plant = "Tomato",
                    Timestamp = DateTime.Now
                };
                Task.Run(() => _dataContext.Readings.AddAsync(temp));
                Task.Run(() => _dataContext.SaveChangesAsync());
                //await _dataContext.Readings.AddAsync(temp);
                //await _dataContext.SaveChangesAsync();
                Console.WriteLine("Added");
               await CreateReading(response.Temp, response.Humid, response.Ox);
            }

        }
        */
    }

}