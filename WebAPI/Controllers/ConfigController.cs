using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services.ConfigService;

namespace WebAPI.Controllers;


[ApiController]
[Route("[controller]/[action]")]
public class ConfigController : ControllerBase
{
    private readonly IConfigService _configService;

    public ConfigController(IConfigService configService)
    {
        _configService = configService;
    }
    
    
    [HttpGet]
    public async Task<ActionResult<List<Config>>> GetConfig()
    {
        return await _configService.GetConfig();
    }

    [HttpPut]
    public async Task<ActionResult<List<Config>>> UpdateConfig(string Plant, int Temperature, int Humidity, int Co2)
    {
        return await _configService.UpdateConfig(Plant, Temperature, Humidity, Co2);
    }
    
    
}