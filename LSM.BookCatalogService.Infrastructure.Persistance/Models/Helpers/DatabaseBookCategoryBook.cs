namespace LSM.BookCatalogService.Infrastructure.Persistance.Models.Helpers;

public sealed class DatabaseBookCategoryBook
{
    public Guid BookId { get; set; }
    public DatabaseBook? Book { get; set; }
    
    public Guid CategoryId { get; set; }
    public DatabaseBookCategory? Category { get; set; }
}