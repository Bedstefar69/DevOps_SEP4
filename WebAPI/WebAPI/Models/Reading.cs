using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebAPI.WebAPI.Models;

public class Reading
{
    [MaxLength(50)][Required]
    public string Plant { get; set; }
    
    [Key]
    public DateTime Timestamp { get; set; }
    
    [Required]
    public double Temperature { get; set; }
    [Required]
    public double Humidity { get; set; }
    [Required]
    public int Co2 { get; set; }
    [ForeignKey("Plant")]  [JsonIgnore]
    public Config Config { get; set; }

}