using Domain.Models;

namespace FileData;

public class DataContainer
{
    public ICollection<Data>? data { get; set; }
    public ICollection<User>? Users { get; set; }
    
}