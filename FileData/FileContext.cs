using System.Reflection;
using System.Text.Json;
using Domain.Models;
using FileData.DAOs;

namespace FileData;

public class FileContext
{
    private const string filePath = "data.json";
    private Datacontainer? dataContainer;


    public ICollection<Data> data
    {
        get
        {
            LoadData();
            return dataContainer!.data;
        }
    }

    private void LoadData()
    {
        if (dataContainer != null) return;
    
        if (!File.Exists(filePath))
        {
            dataContainer = new ()
            {
                data = new List<Data>()
                
            };
            return;
        }
        string content = File.ReadAllText(filePath);
        dataContainer = JsonSerializer.Deserialize<Datacontainer>(content);
    }

    public void SaveChanges()
    {
        string serialized = JsonSerializer.Serialize(dataContainer, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(filePath, serialized);
        dataContainer = null;
    }
}