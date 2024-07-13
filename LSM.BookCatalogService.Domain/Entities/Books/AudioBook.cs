using LSM.BookCatalogService.Domain.Entities.Creators;
using LSM.BookCatalogService.Domain.ValueObjects;

namespace LSM.BookCatalogService.Domain.Entities.Books;

public sealed class AudioBook : Book
{
    public override bool IsAvailable => true;
    public byte[] Content { get; }

    public AudioBook(
        string name,
        int publishingYear,
        Isbn isbn,
        List<BookCategory> categories,
        List<BookGenre> genres, 
        byte[] content, 
        string? annotation = null,
        params Author[] authors
    ) : base(name, publishingYear, isbn, categories, genres, annotation, authors)
    {
        if (content is not { Length: > 0 })
        {
            throw new ArgumentException("Содержимое аудио-книги не может быть пустым!", nameof(content));
        }
        
        Content = content;
    }
}