using Microsoft.AspNetCore.Mvc;
using WebAPI.WebAPI.Data.DTOer;
using WebAPI.WebAPI.Models;
using WebAPI.WebAPI.Services.ConfigService;

namespace WebAPI.WebAPI.Controllers;


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

    [HttpGet]
    public async Task<ActionResult<List<Config>>> GetConfigByName(string name)
    {
        return await _configService.GetConfigByName(name);
    }
    
    
    [HttpPut]
    public async Task UpdateConfig([FromBody] UpdateConfigDTO request)
    {
        if (ModelState.IsValid)
        {
            await _configService.UpdateConfig(request);
        }
    }

    [HttpPost]
    public async Task<ActionResult<List<Config>>> createConfig(CreateConfigDTO request)
    {
        return await _configService.createConfig(request);
    }
    
    
}