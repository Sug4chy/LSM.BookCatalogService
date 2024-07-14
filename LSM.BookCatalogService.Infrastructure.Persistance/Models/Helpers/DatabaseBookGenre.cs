namespace LSM.BookCatalogService.Infrastructure.Persistance.Models.Helpers;

public sealed class DatabaseBookGenre
{
    public Guid BookId { get; set; }
    public DatabaseBook? Book { get; set; }
    
    public Guid GenreId { get; set; }
    public DatabaseGenre? Genre { get; set; }
}