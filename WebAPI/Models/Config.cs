using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models;

public class Config
{
    [Key][MaxLength(50)]
    public string Plant { get; set; }
    [Required]
    public int MinTemperature { get; set; }
    [Required]
    public int MaxTemperature { get; set; }
    [Required]
    public int MinHumidity { get; set; }
    [Required]
    public int MaxHumidity { get; set; }
    [Required]
    public int MinCo2 { get; set; }
    [Required]
    public int MaxCo2 { get; set; }
}