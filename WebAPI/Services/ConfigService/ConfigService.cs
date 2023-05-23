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

    public async Task<ActionResult<List<Config>>> UpdateConfig(Config config)
    {
        _dataContext.Config.Update(config);
        await _dataContext.SaveChangesAsync();
        
        return await _dataContext.Config.ToListAsync();
    }
}