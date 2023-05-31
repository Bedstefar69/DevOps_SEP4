using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.WebAPI.Controllers;
using WebAPI.WebAPI.Models;
using WebAPI.WebAPI.Services.ConfigService;
using WebAPI.WebAPI.Services.ReadingService;
using Xunit;

namespace UnitTestingWebAPI;

// IKKE FUNKTIONELT
public class ReadingControllerTests
{
    [Fact]
    public async Task CreateReadingShouldReturnTrue()
    {
        /// Arrange
        var testobj = new Reading()
        {
            Temperature = 20,
            Humidity = 20,
            Co2 = 550,
        };
        
        var readingService = new Mock<IReadingService>();
        readingService.Setup(_ => _.CreateReading(20,20,500).Result).Returns(true);
        var sut = new ReadingController(readingService.Object);
 
        /// Act
        var result = sut.Response.Body.;
        // /// Assert
        result
    }
    
    
    // IKKE FUNKTIONELT
    [Fact]
    public async Task CreateReadingShouldReturnFalse()
    {
        /// Arrange
        
        var readingService = new Mock<IReadingService>();
        readingService.Setup(_ => _.CreateReading(20,20,999).Result).Returns(false);
        var sut = new ReadingController(readingService.Object);
 
        /// Act
        
        // /// Assert
        readingService.Should().Be(false);
    }
}