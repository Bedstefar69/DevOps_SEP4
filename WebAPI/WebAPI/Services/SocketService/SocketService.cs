using gRPCWebSocket;
using WebAPI.WebAPI.Data;
using WebAPI.WebAPI.Models;
using WebAPI.WebSocket.LogicImpl;

namespace WebAPI.WebAPI.Services.SocketService;

public class SocketService : IHostedService
{
    private readonly DataContext _dataContext;
    private readonly string SERVER_IP = "http://70.34.254.24:4242";
    private Timer? _timer = null;
    private readonly ILogger<SocketService> _logger;

    private WebSocketLogicImpl _webSocketLogicImpl;

    public SocketService(DataContext dataContext, ILogger<SocketService> logger)
    {
        _webSocketLogicImpl = new WebSocketLogicImpl(SERVER_IP);
        _dataContext = dataContext;
        _logger = logger;
    }

    public async Task<ConfigResponse> setConfig(NewConfig config)
    {
        
        throw new NotImplementedException();
    }

    public async void getUpdate(object? state)
    {
        Console.WriteLine("Getting readings automatically");
            Console.WriteLine("Checking for a reading");
            var response = await _webSocketLogicImpl.getUpdate(new Update
            {
                Response = "getReadings"
            });

            if (response.Temp < 999.0) //Checker hvis der har været en ny reading - ellers returner den en fallback værdi på 999.9
            {
                await CreateReading(response.Temp, response.Humid, response.Ox);
        }
    }

    public async Task<ConnectionResponse> getConnection()
    {
        throw new NotImplementedException();
    }
    
    
    
    
    private async Task<bool> CreateReading(double temperature, double humidity, int co2)
    {
        var temp = new Reading()
        {
            Co2 = co2,
            Humidity = humidity,
            Temperature = temperature,
            Plant = "Tomato",
            Timestamp = DateTime.Now
        };
        
        _dataContext.Readings.Add(temp);
        var created = await _dataContext.SaveChangesAsync();
        return created > 0;

    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting auto-updates");
        _timer = new Timer(getUpdate, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));

    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Stopping auto-updates");
        _timer?.Change(Timeout.Infinite, 0);
    }
}