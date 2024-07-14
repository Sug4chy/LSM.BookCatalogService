using LSM.BookCatalogService.Infrastructure.Persistance.Models;
using Microsoft.EntityFrameworkCore;

namespace LSM.BookCatalogService.Infrastructure.Persistance;

public class DatabaseContext() : DbContext
{
    public DbSet<DatabaseBook> Books { get; init; }
    public DbSet<DatabaseAuthor> Authors { get; init; }
    public DbSet<DatabaseCountry> Countries { get; init; }
    public DbSet<DatabasePortrait> Portraits { get; init; }
    public DbSet<DatabaseIllustration> Illustrations { get; init; }
    public DbSet<DatabaseIllustrator> Illustrators { get; init; }
    public DbSet<DatabasePortraitCreator> PortraitCreators { get; init; }
    public DbSet<DatabaseBookCategory> Categories { get; init; }
    public DbSet<DatabaseGenre> Genres { get; init; }
    public DbSet<DatabaseVoiceActor> VoiceActors { get; init; }
    public DbSet<DatabasePublishingHouse> PublishingHouses { get; init; }
    
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : this()
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