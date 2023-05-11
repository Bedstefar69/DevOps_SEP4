
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;

public class User
{
    [Key]
    public string Username { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
}