using LSM.BookCatalogService.Infrastructure.Persistance.Models;
using Microsoft.EntityFrameworkCore;

namespace LSM.BookCatalogService.Infrastructure.Persistance;

public class DataContext() : DbContext
{
    public DbSet<DatabaseBook> Books { get; init; }
    public DbSet<DatabaseAuthor> Authors { get; init; }
    public DbSet<DatabaseCountry> Countries { get; init; }
    public DbSet<DatabasePortrait> Portraits { get; init; }
    
    public DataContext(DbContextOptions<DataContext> options) : this()
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }
}