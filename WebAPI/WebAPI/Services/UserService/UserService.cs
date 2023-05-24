using WebAPI.WebAPI.Data;
using WebAPI.WebAPI.Models;

namespace WebAPI.WebAPI.Services.UserService;

public class UserService : IUserService
{
    private readonly DataContext _context;

    public UserService(DataContext context)
    {
        _context = context;
    }

    public bool GetUser(string username, string password)
    {
        User tempuser = new User
        {
            Username = username,
            Password = password
        };

        return (_context.Users.Contains(tempuser));
    }

    public async Task CreateUser(string username, string password)
    {
        User tempuser = new User
        {
            Username = username,
            Password = password
        };
        
        _context.Users.Add(tempuser);
        await _context.SaveChangesAsync();
        
    }
}