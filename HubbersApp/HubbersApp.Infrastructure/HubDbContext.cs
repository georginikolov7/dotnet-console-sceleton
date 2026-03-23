using HubbersApp.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HubbersApp.Infrastructure;

public class HubDbContext : DbContext
{
    public HubDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Hubber> Hubbers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HubDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}