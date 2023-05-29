using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebAPI.WebAPI.Models;

public class Note
{
    [Key] [MaxLength(50)]
    public string Plant { get; set; }
    [MaxLength(250)]
    public string NoteString { get; set; }
    
    [ForeignKey("Plant")]
    public Config Config { get; set; }
}