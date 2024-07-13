using LSM.BookCatalogService.Domain.Entities.Creators;
using LSM.BookCatalogService.Domain.ValueObjects;

namespace LSM.BookCatalogService.Domain.Entities.Books;

public abstract class Book
{
    private readonly List<Author> _authors;
    private readonly List<BookCategory> _categories;
    private readonly List<BookGenre> _genres;

    public string Name { get; }
    public IReadOnlyList<Author> Authors => _authors.AsReadOnly();
    public int PublishingYear { get; }
    public Isbn Isbn { get; }
    public abstract bool IsAvailable { get; }
    public string? Annotation { get; }
    public IReadOnlyList<BookCategory> Categories => _categories.AsReadOnly();
    public IReadOnlyList<BookGenre> Genres => _genres.AsReadOnly();


    internal Book(
        string name,
        int publishingYear,
        Isbn isbn,
        List<BookCategory> categories,
        List<BookGenre> genres,
        string? annotation = null,
        params Author[] authors
    )
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
        ArgumentNullException.ThrowIfNull(isbn, nameof(isbn));

        Name = name;
        PublishingYear = publishingYear;
        Isbn = isbn;
        _categories = categories;
        _genres = genres;
        Annotation = annotation;
        _authors = [..authors];
    }
}