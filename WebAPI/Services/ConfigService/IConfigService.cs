using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Services.ConfigService;

public interface IConfigService
{
    public Task<ActionResult<List<Config>>> GetConfig();
    public Task<ActionResult<List<Config>>> UpdateConfig(string Plant, int minTemperature, int maxTemperature,int minHumidity,int maxHumidity, int minCo2, int maxCo2);
}