using Domain.Models;

namespace Application.DAO_Interfaces;

public interface IDataDAO
{
    
    Task<Data> CreateAsync(Data data);
    Task<Data?> GetByID(int id);
}