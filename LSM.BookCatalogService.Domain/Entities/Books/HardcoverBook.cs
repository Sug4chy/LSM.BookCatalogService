using LSM.BookCatalogService.Domain.Entities.Creators;
using LSM.BookCatalogService.Domain.Entities.Images;
using LSM.BookCatalogService.Domain.Interfaces;
using LSM.BookCatalogService.Domain.ValueObjects;

namespace LSM.BookCatalogService.Domain.Entities.Books;

public sealed class HardcoverBook(
    string name,
    int publishingYear,
    Isbn isbn,
    int countInLibrary,
    int pagesCount,
    List<BookCategory> categories,
    List<BookGenre> genres,
    List<Illustration> illustrations,
    string? annotation = null,
    params Author[] authors
) : Book(name, publishingYear, isbn, categories, genres, annotation, authors), IHasIllustrations
{
    public override bool IsAvailable => AvailableCount > 0;
    public int AvailableCount { get; } = countInLibrary;
    public int CountInLibrary { get; } = countInLibrary;
    public int PagesCount { get; } = pagesCount;
    public IReadOnlyList<Illustration> Illustrations => illustrations.AsReadOnly();
}