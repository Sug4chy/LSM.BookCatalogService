using LSM.BookCatalogService.Infrastructure.Persistance.Models.Helpers;

namespace LSM.BookCatalogService.Infrastructure.Persistance.Models;

public sealed class DatabaseAuthor
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Email { get; set; }
    public Dictionary<string, string>? ContactInformation { get; set; }
    public DateTime? DeathDate { get; set; }
    public string? ShortBiography { get; set; }
    
    public ICollection<DatabaseAuthorBook>? Books { get; set; }
    
    public Guid CountryId { get; set; }
    public DatabaseCountry? Country { get; set; }
    
    public DatabasePortrait? Portrait { get; set; }
}