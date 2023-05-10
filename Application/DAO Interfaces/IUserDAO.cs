using Domain.DTOs;
using Domain.Models;

namespace Application.DAO_Interfaces;

public interface IUserDAO
{
    Task<User> createAsync(User user);
    Task<User?> GetByUsernameAsync(string userName);

}