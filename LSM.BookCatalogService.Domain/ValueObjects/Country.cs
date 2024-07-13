namespace LSM.BookCatalogService.Domain.ValueObjects;

public class Country(string name)
{
    public string Name { get; } = name;
}