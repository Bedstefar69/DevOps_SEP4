namespace WebAPI.WebAPI.Services.UserService;
// BLIVER IKKE FÆRDIG IMPLEMENTERET
public interface IUserService
{
   public Boolean GetUser(string username, string password);
   public Task CreateUser(string username, string password);
}