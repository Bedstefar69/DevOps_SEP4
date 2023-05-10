using Domain.DTOs;
using Domain.Models;

namespace Application.Logic_Interfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(UserCreationDTO userToCreate);
}