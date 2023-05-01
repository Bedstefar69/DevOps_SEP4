using Domain.DTOs;
using Domain.Models;

namespace Application.Logic_Interfaces;

public interface IDataLogic
{
    Task<Data> CreateAsync(Data data);
    public Task<IEnumerable<Data>> GetAsync(GetDataDTO searchParams);
}