using Microsoft.AspNetCore.Mvc;
using WebAPI.WebAPI.Models;

namespace WebAPI.WebAPI.Services.NoteService;

public interface INoteService
{
    public Task<ActionResult<List<Note>>> GetNote();
    public Task<ActionResult<List<Note>>> CreateNote(string plantname, string? notes);
}