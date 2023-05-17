using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models;

public class Reading
{
    [Key]
    public DateTime Timestamp { get; set; }
    
    [MaxLength(50)]
    public string Plant { get; set; }
    
    [Required]
    public int Temperature { get; set; }
    [Required]
    public int Humidity { get; set; }
    [Required]
    public int Co2 { get; set; }



}