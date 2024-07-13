namespace LSM.BookCatalogService.Domain.ValueObjects;

public class BookCategory(string name)
{
    public string Name { get; } = name;
}