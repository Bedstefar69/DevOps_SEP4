using Microsoft.AspNetCore.Mvc;
using WebAPI.Services.UserService;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly IUserService _IUserService;

    public UserController(IUserService userService)
    {
        _IUserService = userService;
    }

    
    [HttpGet(Name = "GetUser")]
    public async Task<ActionResult<Boolean>> GetUser(string username, string password)
    {
        return Ok(_IUserService.GetUser(username, password));
    } //Mangler impl
    
    /*public async Task<ActionResult<List<User>>> Get()
    {
        return Ok(await _context.Users.ToListAsync());
    }*/

    [HttpPost]
    public async Task<OkResult> CreateUser(string username, string password)
    {
        _IUserService.CreateUser(username, password);
        
        return Ok();
        
        //Mangler impl
    }
}