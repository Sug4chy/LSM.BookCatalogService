using LSM.BookCatalogService.Infrastructure.Persistance.Models.Discriminators;
using LSM.BookCatalogService.Infrastructure.Persistance.Models.Helpers;

namespace LSM.BookCatalogService.Infrastructure.Persistance.Models;

public sealed class DatabaseBook
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public short PublishingYear { get; set; }
    public required string Isbn { get; set; }
    public bool IsAvailable { get; set; }
    public string? Annotation { get; set; }
    public DatabaseBookDiscriminator Discriminator { get; set; }
    public int? AvailableCount { get; set; }
    public int? CountInLibrary { get; set; }
    public int? PagesCount { get; set; }
    public string? FilePath { get; set; }
    
    // TODO: VoiceActor (ID here)
    // TODO: Illustrations
    // TODO: Categories (N:N)
    // TODO: Genres (N:N)
    // TODO: PublishingHouse (ID here)
    public ICollection<DatabaseAuthorBook>? Authors { get; set; }
}