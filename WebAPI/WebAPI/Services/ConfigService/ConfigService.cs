using gRPCWebSocket;
using Microsoft.AspNetCore.Mvc;
using WebAPI.WebAPI.Data;
using WebAPI.WebAPI.Data.DTOer;
using WebAPI.WebAPI.Models;

namespace WebAPI.WebAPI.Services.ConfigService;

public class ConfigService : IConfigService
{

    private readonly DataContext _dataContext;

    public ConfigService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IActionResult> GetConfig()
    {
        var configurations = await _dataContext.Config.Include(config => config.Notes).Include(c => c.Readings).ToListAsync();
        return new OkObjectResult(configurations);
    }
    
    public async Task<IActionResult> GetConfigByName(string name)
    {
        var configurations = await _dataContext.Config.Where(c => c.Plant == name).Include(c => c.Notes).Include(c => c.Readings).ToListAsync();

        return new OkObjectResult(configurations);
    }
    

    public async Task UpdateConfig(UpdateConfigDTO request)
    {
        Config tempconfig = new Config()
        { 
            Plant = request.Plant,
            MinTemperature = request.MinTemperature,
            MaxTemperature = request.MaxTemperature,
            MinHumidity = request.MinHumidity,
            MaxHumidity = request.MaxHumidity,
            MinCo2 = request.MinCo2,
            MaxCo2 = request.MaxCo2,
        };
        
        await SocketService.SocketService.setConfig(new NewConfig
        {
            MaxHumid = request.MaxHumidity,
            MaxOx = request.MaxCo2,
            MaxTemp = request.MaxTemperature,
            MinHumid = request.MinHumidity,
            MinOx = request.MinCo2,
            MinTemp = request.MinTemperature
        });
        
        _dataContext.Config.Update(tempconfig);
        await _dataContext.SaveChangesAsync();
    }

    public async Task<ActionResult<List<Config>>> createConfig(CreateConfigDTO request)
    {
        Config tempconfig = new Config()
        { 
            Plant = request.Plant,
            MinTemperature = request.MinTemperature,
            MaxTemperature = request.MaxTemperature,
            MinHumidity = request.MinHumidity,
            MaxHumidity = request.MaxHumidity,
            MinCo2 = request.MinCo2,
            MaxCo2 = request.MaxCo2,
            Notes = new Note {NoteString = "Ingen noter"},
        };

        _dataContext.Config.Add(tempconfig);
        await _dataContext.SaveChangesAsync();
        
        return await _dataContext.Config.ToListAsync();
    }
}