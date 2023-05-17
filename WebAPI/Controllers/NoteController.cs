using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services.NoteService;

namespace WebAPI.Controllers;


[ApiController]
[Route("[controller]/[action]")]
public class NoteController : ControllerBase
{
    private readonly INoteService _noteService;

    public NoteController(INoteService noteService)
    {
        _noteService = noteService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Note>>> GetNote()
    {
        return Ok(await _noteService.GetNote());
    }

    [HttpPost]
    public async Task<ActionResult<List<Note>>> CreateNote(string plantname, string? notes)
    {
        return Ok(await _noteService.CreateNote(plantname, notes));
    }
    
    
}