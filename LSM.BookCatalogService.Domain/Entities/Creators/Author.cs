using LSM.BookCatalogService.Domain.Entities.Books;
using LSM.BookCatalogService.Domain.Entities.Images;
using LSM.BookCatalogService.Domain.ValueObjects;

namespace LSM.BookCatalogService.Domain.Entities.Creators;

public sealed class Author(
    string name,
    DateTime birthDate,
    Country placeOfBirth,
    ContactInformation? contactInformation = null,
    DateTime? deathDate = null,
    string? shortBiography = null,
    Portrait? portrait = null
) : Creator(name, birthDate, placeOfBirth, contactInformation, deathDate, shortBiography, portrait)
{
    private readonly List<Book> _books = [];

    public IReadOnlyList<Book> Books => _books.AsReadOnly();

    public void AddBook(Book book)
    {
        ArgumentNullException.ThrowIfNull(book, nameof(book));
        
        _books.Add(book);
    }
}