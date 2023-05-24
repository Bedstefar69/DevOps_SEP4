using Microsoft.AspNetCore.Mvc;
using WebAPI.WebAPI.Data.DTOer;
using WebAPI.WebAPI.Models;

namespace WebAPI.WebAPI.Services.ConfigService;

public interface IConfigService
{
    public Task<ActionResult<List<Config>>> GetConfig();
    public Task UpdateConfig([FromBody] UpdateConfigDTO request);
    public Task<ActionResult<List<Config>>> createConfig(CreateConfigDTO request);
    
    public Task<ActionResult<List<Config>>> GetConfigByName(string name);
}