namespace LSM.BookCatalogService.Infrastructure.Persistance.Models;

public sealed class DatabaseGenre
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    
    public ICollection<DatabaseBook>? Books { get; set; }
}