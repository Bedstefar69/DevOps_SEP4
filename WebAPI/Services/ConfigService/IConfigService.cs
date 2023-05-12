using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Services.ConfigService;

public interface IConfigService
{
    public Task<ActionResult<List<Config>>> GetConfig();
    public Task<ActionResult<List<Config>>> UpdateConfig(string Plant, int Temperature, int Humidity, int Co2);
}