namespace LSM.BookCatalogService.Infrastructure.Persistance.Models;

public sealed class DatabaseCountry
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    
    public ICollection<DatabaseAuthor>? Authors { get; set; }
    
    public ICollection<DatabaseVoiceActor>? VoiceActors { get; set; }
    
    public ICollection<DatabaseIllustrator>? Illustrators { get; set; }
    
    public ICollection<DatabasePortraitCreator>? PortraitCreators { get; set; }
}