using Domain.Models;

namespace Application.Logic_Interfaces;

public interface IDataLogic
{
    Task<Data> CreateAsync(Data data);
}