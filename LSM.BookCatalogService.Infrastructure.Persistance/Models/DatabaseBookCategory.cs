using LSM.BookCatalogService.Infrastructure.Persistance.Models.Helpers;

namespace LSM.BookCatalogService.Infrastructure.Persistance.Models;

public sealed class DatabaseBookCategory
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    
    public ICollection<DatabaseBookCategoryBook>? Books { get; set; }
}