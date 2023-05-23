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
        return  Ok(await _configService.GetConfig());
    }
    
    [HttpPut]
    public async Task<ActionResult<List<Config>>> UpdateConfig([FromBody] Config config)
    {
        return Ok(await _configService.UpdateConfig(config));
    }
    
    
}