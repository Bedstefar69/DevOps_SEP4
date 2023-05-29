using Microsoft.AspNetCore.Mvc;
using WebAPI.WebAPI.Data;
using WebAPI.WebAPI.Models;

namespace WebAPI.WebAPI.Services.NoteService;

public class NoteService : INoteService
{
    private readonly DataContext _dataContext;

    public NoteService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ActionResult<List<Note>>> GetNote()
    {
        return await _dataContext.Notes.ToListAsync();
    }

    public async Task<ActionResult<List<Note>>> CreateNote(string plantname, string? notes)
    {
        var plant = new Note()
        {
            Plant = plantname,
            NoteString = notes
        };

        _dataContext.Notes.Add(plant);
        await _dataContext.SaveChangesAsync();

        return _dataContext.Notes.ToList();

    }
}