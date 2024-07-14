namespace LSM.BookCatalogService.Infrastructure.Persistance.Models.Helpers;

public sealed class DatabaseBookGenre
{
    public Guid BookId { get; set; }
    public Guid GenreId { get; set; }
}