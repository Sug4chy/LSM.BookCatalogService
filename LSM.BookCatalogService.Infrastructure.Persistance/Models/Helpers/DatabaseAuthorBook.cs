namespace LSM.BookCatalogService.Infrastructure.Persistance.Models.Helpers;

public sealed class DatabaseAuthorBook
{
    public Guid BookId { get; set; }
    public DatabaseBook? Book { get; set; }
    
    public Guid AuthorId { get; set; }
    public DatabaseAuthor? Author { get; set; }
}