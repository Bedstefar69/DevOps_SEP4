using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WebAPI.WebAPI.Models;

public class Config
{
    [Key][MaxLength(50)]
    public string Plant { get; set; }
    [Required]
    public double MinTemperature { get; set; }
    [Required]
    public double MaxTemperature { get; set; }
    [Required]
    public double MinHumidity { get; set; }
    [Required]
    public double MaxHumidity { get; set; }
    [Required]
    public int MinCo2 { get; set; }
    [Required]
    public int MaxCo2 { get; set; }
    
    [JsonIgnore]
    public Note Notes { get; set; }
    [JsonIgnore]
    public List<Reading> Readings { get; set; } = new List<Reading>();
}