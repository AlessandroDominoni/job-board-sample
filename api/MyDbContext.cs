using api.Models;
using Microsoft.EntityFrameworkCore;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    public DbSet<PositionViewModel> Positions { get; set; }
    public DbSet<ApplicationViewModel> Applications { get; set; }
}
