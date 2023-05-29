using WebAPI.WebAPI.Models;

namespace WebAPI.WebAPI.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<Reading> Readings { get; set; }
    
    public DbSet<Config> Config { get; set; }
}