using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly DataContext _context;

    public UserController(DataContext context)
    {
        _context = context;
    }
    
    
    
    [HttpGet(Name = "GetUsers") ]
    public async Task<ActionResult<List<User>>> Get()
    {
        return Ok(await _context.Users.ToListAsync());
    }

    [HttpPost]
    public async Task<ActionResult<List<User>>> CreateUser(User tempuser)
    {
        _context.Users.Add(tempuser);
        await _context.SaveChangesAsync();
        return Ok(await _context.Users.ToListAsync());
    }
}