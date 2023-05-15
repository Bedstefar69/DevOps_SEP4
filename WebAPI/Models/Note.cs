using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;

public class Note
{
    [Key] [MaxLength(50)][Required]
    public string Plant { get; set; }
    [MaxLength(250)]
    public string NoteString { get; set; }
    
}