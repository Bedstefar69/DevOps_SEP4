
using System.ComponentModel.DataAnnotations;

namespace WebAPI.WebAPI.Models;

public class User
{
    [Key][Required]
    public string Username { get; set; } = String.Empty;
    [Required]
    public string Password { get; set; } = String.Empty;
    
    
}