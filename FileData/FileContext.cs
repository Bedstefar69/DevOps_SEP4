using System.Text.Json;
using Domain.Models;

namespace FileData;

public class FileContext
{
    private const string filePath = "data.json";

    private Datacontainer? dataContainer;

    public ICollection<Data> data
    {
        get
        {
            LazyLoadData();
            return dataContainer!.data;
        }
    }
    

    private void LazyLoadData()
    {
        if (dataContainer == null)
        {
            LoadData();
        }
    }

    private void LoadData()
    {
        string content = File.ReadAllText(filePath);
        dataContainer = JsonSerializer.Deserialize<Datacontainer>(content);
    }

    public void SaveChanges()
    {
        string serialized = JsonSerializer.Serialize(dataContainer);
        File.WriteAllText(filePath, serialized);
        dataContainer = null;
    }
}