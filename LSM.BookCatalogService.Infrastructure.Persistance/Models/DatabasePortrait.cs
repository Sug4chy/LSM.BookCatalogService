using LSM.BookCatalogService.Infrastructure.Persistance.Models.Discriminators;

namespace LSM.BookCatalogService.Infrastructure.Persistance.Models;

public sealed class DatabasePortrait
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string FilePath { get; set; }
    public DatabasePortraitDiscriminator Discriminator { get; set; }
    
    public Guid AuthorId { get; set; }
    public DatabaseAuthor? Author { get; set; }
    
    public Guid CreatorId { get; set; }
    public DatabasePortraitCreator? Creator { get; set; }
}