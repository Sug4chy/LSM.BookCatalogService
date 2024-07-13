using LSM.BookCatalogService.Domain.Entities.Creators;
using LSM.BookCatalogService.Domain.Entities.Images;
using LSM.BookCatalogService.Domain.Interfaces;
using LSM.BookCatalogService.Domain.ValueObjects;

namespace LSM.BookCatalogService.Domain.Entities.Books;

public sealed class EBook : Book, IHasIllustrations
{
    private readonly List<Illustration> _illustrations;

    public override bool IsAvailable => true;
    public byte[] Content { get; }
    public IReadOnlyList<Illustration> Illustrations => _illustrations.AsReadOnly();

    public EBook(
        string name,
        int publishingYear,
        Isbn isbn,
        List<BookCategory> categories,
        List<BookGenre> genres,
        byte[] content,
        List<Illustration> illustrations,
        string? annotation = null,
        params Author[] authors
    ) : base(name, publishingYear, isbn, categories, genres, annotation, authors)
    {
        if (content is not { Length: > 0 })
        {
            throw new ArgumentException("Содержимое электронной книги не может быть пустым!", nameof(content));
        }

        Content = content;
        _illustrations = illustrations;
    }
}