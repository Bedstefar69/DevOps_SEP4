using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Services.NoteService;

public interface INoteService
{
    public Task<ActionResult<List<Note>>> GetNote();
    public Task<ActionResult<List<Note>>> CreateNote(string plantname, string? notes);
}