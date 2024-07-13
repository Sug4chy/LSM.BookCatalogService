namespace LSM.BookCatalogService.Domain.ValueObjects;

public class BookGenre(string name)
{
    public string Name { get; } = name;
}