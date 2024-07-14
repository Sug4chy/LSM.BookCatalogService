namespace LSM.BookCatalogService.Infrastructure.Persistance.Models;

public sealed class DatabasePublishingHouse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public short IsbnCode { get; set; }
    
    public ICollection<DatabaseBook>? Books { get; set; }
}