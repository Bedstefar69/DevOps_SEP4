using Microsoft.AspNetCore.Mvc;
using WebAPI.WebAPI.Data.DTOer;
using WebAPI.WebAPI.Models;

namespace WebAPI.WebAPI.Services.ConfigService;

public interface IConfigService
{
    public Task<IActionResult> GetConfig();
    public Task UpdateConfig([FromBody] UpdateConfigDTO request);
    public Task<ActionResult<List<Config>>> createConfig(CreateConfigDTO request);
    
    public Task<IActionResult> GetConfigByName(string name);
}