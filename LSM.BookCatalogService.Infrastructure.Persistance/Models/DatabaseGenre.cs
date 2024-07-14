using LSM.BookCatalogService.Infrastructure.Persistance.Models.Helpers;

namespace LSM.BookCatalogService.Infrastructure.Persistance.Models;

public sealed class DatabaseGenre
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    
    public ICollection<DatabaseBookGenre>? Books { get; set; }
}