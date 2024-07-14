namespace LSM.BookCatalogService.Infrastructure.Persistance.Models;

public sealed class DatabaseIllustrator
{
    public Guid Id { get; set; }
    public required string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Email { get; set; }
    public Dictionary<string, string>? ContactInformation { get; set; }
    public DateTime? DeathDate { get; set; }
    public string? ShortBiography { get; set; }
    
    public Guid CountryId { get; set; }
    public DatabaseCountry? Country { get; set; }
    
    public ICollection<DatabaseIllustration>? Illustrations { get; set; }
}