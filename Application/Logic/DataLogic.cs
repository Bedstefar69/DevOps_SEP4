using Application.DAO_Interfaces;
using Application.Logic_Interfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class DataLogic : IDataLogic
{

    private readonly IDataDAO dao;

    public DataLogic(IDataDAO dao)
    {
        this.dao = dao;
    }
    public async Task<Data> CreateAsync(Data data)
    {
        Data? existing = await dao.GetByID(data.Id);
        if (existing != null)
            throw new Exception("ID already taken!");

        ValidateData(data);
        Data toCreate = new Data(data.Id,data.Body);
        
        
    
        Data created = await dao.CreateAsync(toCreate);
    
        return created;
    }

    public Task<IEnumerable<Data>> GetAsync(GetDataDTO searchParams)
    {
        return dao.GetAsync(searchParams);
    }

    private static void ValidateData(Data data)
    {
        int id = data.Id;
    }
}