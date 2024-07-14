namespace LSM.BookCatalogService.Infrastructure.Persistance.Models;

public sealed class DatabaseCountry
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    
    public ICollection<DatabaseAuthor>? Authors { get; set; }
    // TODO: VoiceActors
    // TODO: Illustrator
    // TODO: PortraitCreators
}