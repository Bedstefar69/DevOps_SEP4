using Application.DAO_Interfaces;
using Domain.Models;

namespace FileData.DAOs;

public class DataFileDAO : IDataDAO
{

    private readonly FileContext context;
    
    public DataFileDAO(FileContext context)
    {
        this.context = context;
    }
    public Task<Data> CreateAsync(Data data)
    {
        int dataID = 1;
        if (context.data.Any())
        {
            dataID = context.data.Max(u => u.Id);
            dataID++;
        }

        data.Id = dataID;

        context.data.Add(data);
        context.SaveChanges();

        return Task.FromResult(data);
    }

    public Task<Data?> GetByID(int id)
    {
        Data? existing = context.data.FirstOrDefault(u =>
            u.Id ==id
        );
        return Task.FromResult(existing);
    }
}