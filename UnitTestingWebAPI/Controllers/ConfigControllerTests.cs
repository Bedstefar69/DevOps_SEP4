using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.WebAPI.Controllers;
using WebAPI.WebAPI.Data.DTOer;
using WebAPI.WebAPI.Models;
using WebAPI.WebAPI.Services.ConfigService;
using Xunit;

namespace UnitTestingWebAPI;

public class ConfigControllerTests
{
    [Fact]
    public async Task GetConfigs_ShouldReturn200Status()
    {
        /// Arrange
        var testobj = new List<Config>()
        {
            new Config()
            {
                Plant = "Tomato",
                MinTemperature = 10,
                MaxTemperature = 10,
                MinHumidity = 10,
                MaxHumidity = 10,
                MinCo2 = 500,
                MaxCo2 = 550
            }
        };
        
        var configService = new Mock<IConfigService>();
        configService.Setup(_ => _.GetConfig()).ReturnsAsync(new OkObjectResult(testobj));
        var sut = new ConfigController(configService.Object);
 
        /// Act
        var result = (OkObjectResult) await sut.GetConfig();
 
 
        // /// Assert
        result.StatusCode.Should().Be(200);
        result.Should().NotBeNull();
        result.Value.Should().BeOfType<List<Config>>();
    }
}



// Testen kunne ikke køres, da der laves en forespørsel til databasen, i form af en IQueryable - Derfor opstod der nogle problemer.

/* [Fact]
 public async Task GetConfigByName_ShouldReturn200Status()
 {
     /// Arrange
     var testobj2 = new List<Config>();
     
     var conf1 =
         new Config()
         {
             Plant = "Tomato",
             MinTemperature = 10,
             MaxTemperature = 10,
             MinHumidity = 10,
             MaxHumidity = 10,
             MinCo2 = 500,
             MaxCo2 = 550
         };
     var conf2 =
         new Config()
         {
             Plant = "Cabbage",
             MinTemperature = 10,
             MaxTemperature = 20,
             MinHumidity = 10,
             MaxHumidity = 20,
             MinCo2 = 500,
             MaxCo2 = 550
         };
     var conf3 =
         new Config()
         {
             Plant = "Cucumber",
             MinTemperature = 10,
             MaxTemperature = 30,
             MinHumidity = 10,
             MaxHumidity = 30,
             MinCo2 = 500,
             MaxCo2 = 550
         };
     testobj2.Add(conf1);
     testobj2.Add(conf2);
     testobj2.Add(conf3);
     
     
     var configService = new Mock<IConfigService>();
     configService.Setup(_ => _.GetConfigByName("Cabbage")).ReturnsAsync(new OkObjectResult(testobj2.Find));
     var sut = new ConfigController(configService.Object);

     /// Act
     var result = (OkObjectResult) await sut.GetConfig();


     // /// Assert
     result.StatusCode.Should().Be(200);
     result.Should().NotBeNull();
     result.Value.Should().BeOfType<List<Config>>();
 }*/