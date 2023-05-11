using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models;

public class Reading
{
    [Key]
    public DateTime Timestamp { get; set; }
    
    [ForeignKey("Name")][MaxLength(50)]
    public string Plant { get; set; }
    
    public int Temperature { get; set; }
    
    public int Humidity { get; set; }
    
    public int Co2 { get; set; }

}