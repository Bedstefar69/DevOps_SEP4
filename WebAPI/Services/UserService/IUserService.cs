using WebAPI.Models;

namespace WebAPI.Services.UserService;

public interface IUserService
{
    IEnumerable<User> GetUsers();
}