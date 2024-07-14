namespace LSM.BookCatalogService.Infrastructure.Persistance.Models;

public sealed class DatabaseIllustration
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string FilePath { get; set; }
    
    public Guid BookId { get; set; }
    public DatabaseBook? Book { get; set; }
    
    public Guid IllustratorId { get; set; }
    public DatabaseIllustrator? Illustrator { get; set; }
}