using LSM.BookCatalogService.Domain.Entities.Creators;
using LSM.BookCatalogService.Domain.Entities.Images;
using LSM.BookCatalogService.Domain.ValueObjects;

namespace LSM.BookCatalogService.Domain.Entities.Books;

public sealed class Magazine(
    string name,
    int publishingYear,
    Isbn isbn,
    int countInLibrary,
    List<BookCategory> categories,
    List<BookGenre> genres,
    int pagesCount,
    List<Illustration> illustrations,
    params Author[] authors
) : PaperbackBook(name, publishingYear, isbn, countInLibrary, categories, genres, pagesCount, illustrations,
    null, authors);