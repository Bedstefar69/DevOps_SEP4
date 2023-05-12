using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Services.ConfigService;

public class ConfigService : IConfigService
{

    private readonly DataContext _dataContext;

    public ConfigService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ActionResult<List<Config>>> GetConfig()
    {
        return await _dataContext.Config.ToListAsync();
    }

    public async Task<ActionResult<List<Config>>> UpdateConfig(string Plant, int Temperature, int Humidity, int Co2)
    {
        Config tempconfig = new Config
        {
            Plant = Plant,
            Temperature = Temperature,
            Humidity = Humidity,
            Co2 = Co2
        };

        _dataContext.Config.Update(tempconfig);
        await _dataContext.SaveChangesAsync();

        return await _dataContext.Config.ToListAsync();
    }
}