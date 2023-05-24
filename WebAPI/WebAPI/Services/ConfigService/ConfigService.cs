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

    public async Task<ActionResult<List<Config>>> GetConfig()
    {
        var configurations = await _dataContext.Config.Include(config => config.Notes).Include(c => c.Readings).ToListAsync();
        return configurations;
    }
    
    public async Task<ActionResult<List<Config>>> GetConfigByName(string name)
    {
        var configurations = await _dataContext.Config.Where(c => c.Plant == name).Include(c => c.Notes).Include(c => c.Readings).ToListAsync();

        return configurations;
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
            Notes = {NoteString = "Ingen noter"},
        };
        tempconfig.Notes.Config = tempconfig;

        _dataContext.Config.Add(tempconfig);
        await _dataContext.SaveChangesAsync();
        
        return await _dataContext.Config.ToListAsync();
    }
}