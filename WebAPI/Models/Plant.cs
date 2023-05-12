using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;

public class Plant
{
    [Key] [MaxLength(50)][Required]
    public string Name { get; set; }
    [MaxLength(250)]
    public string Notes { get; set; }
    
}