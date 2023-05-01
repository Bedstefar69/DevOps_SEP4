using Application.Logic_Interfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DataController : ControllerBase
{
    private readonly IDataLogic dataLogic;

    public DataController(IDataLogic dataLogic)
    {
        this.dataLogic = dataLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<Data>> CreateAsync(Data dto)
    {
        try
        {
            Data data = await dataLogic.CreateAsync(dto);
            return Created($"/data/{data.Id}", data);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Data>>> GetAsync([FromQuery] string? body)
    {
        try
        {
            GetDataDTO parameters = new GetDataDTO(body);
            IEnumerable<Data> data = await dataLogic.GetAsync(parameters);
            return Ok(data);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}