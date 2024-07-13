using System.Collections;
using LSM.BookCatalogService.Domain.Entities.Books;
using LSM.BookCatalogService.Domain.Entities.Creators;
using LSM.BookCatalogService.Domain.Entities.Images;
using LSM.BookCatalogService.Domain.ValueObjects;

namespace LSM.BookCatalogService.Domain.Helpers;

public class BookBuilder(int countryCode, int publisherCode, int uniqueBookCode)
{
    private string _name = null!;
    private readonly Isbn _isbn = new(countryCode, publisherCode, uniqueBookCode, countryCode is 5);
    private readonly List<Author> _authors = [];
    private int _publishingYear;
    private string? _annotation;
    private readonly List<BookCategory> _categories = [];
    private readonly List<BookGenre> _genres = [];
    private readonly List<Illustration> _illustrations = [];

    public BookBuilder WithName(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));

        _name = name;
        return this;
    }

    public BookBuilder WithAuthor(Author author)
    {
        ArgumentNullException.ThrowIfNull(author, nameof(author));

        _authors.Add(author);
        return this;
    }

    public BookBuilder WithAuthors(params Author[] authors)
    {
        if (authors is not { Length: > 0 })
        {
            throw new ArgumentException("Список авторов не должен быть пустым", nameof(authors));
        }

        _authors.AddRange(authors);
        return this;
    }

    public BookBuilder PublishedInYear(int year)
    {
        _publishingYear = year;
        return this;
    }

    public BookBuilder WithAnnotation(string annotation)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(annotation, nameof(annotation));

        _annotation = annotation;
        return this;
    }

    public BookBuilder WithCategories(params BookCategory[] categories)
    {
        if (categories is not { Length: > 0 })
        {
            throw new ArgumentException("Список категорий не должен быть пустым", nameof(categories));
        }

        _categories.AddRange(categories);
        return this;
    }

    public BookBuilder InGenres(params BookGenre[] genres)
    {
        if (genres is not { Length: > 0 })
        {
            throw new ArgumentException("Список жанров не должен быть пустым", nameof(genres));
        }

        _genres.AddRange(genres);
        return this;
    }

    public BookBuilder WithIllustrations(params Illustration[] illustrations)
    {
        if (illustrations is not { Length: > 0 })
        {
            throw new ArgumentException("Список иллюстраций не должен быть пустым", nameof(illustrations));
        }

        _illustrations.AddRange(illustrations);
        return this;
    }

    public AudioBook PublishAudioBook(byte[] content)
    {
        BookBuilderException.ThrowIfNullOrEmpty(_name, "название");
        BookBuilderException.ThrowIfNullOrEmpty(_categories, "категории");
        BookBuilderException.ThrowIfNullOrEmpty(_genres, "жанры");
        BookBuilderException.ThrowIfNullOrEmpty(content, "содержимое файла");
        BookBuilderException.ThrowIfNullOrEmpty(_authors, "авторы");
        if (_publishingYear is 0)
        {
            throw new BookBuilderException("Для создания книги не достаёт параметра - год публикации");
        }

        return new AudioBook(
            _name,
            _publishingYear,
            _isbn,
            _categories,
            _genres,
            content,
            _annotation,
            [.._authors]
        );
    }

    public EBook PublishEBook(byte[] content)
    {
        BookBuilderException.ThrowIfNullOrEmpty(_name, "название");
        BookBuilderException.ThrowIfNullOrEmpty(_categories, "категории");
        BookBuilderException.ThrowIfNullOrEmpty(_genres, "жанры");
        BookBuilderException.ThrowIfNullOrEmpty(content, "содержимое файла");
        BookBuilderException.ThrowIfNullOrEmpty(_authors, "авторы");
        BookBuilderException.ThrowIfNullOrEmpty(_illustrations, "иллюстрации");
        if (_publishingYear is 0)
        {
            throw new BookBuilderException("Для создания книги не достаёт параметра - год публикации");
        }

        return new EBook(
            _name,
            _publishingYear,
            _isbn,
            _categories,
            _genres,
            content,
            _illustrations,
            _annotation,
            [.._authors]
        );
    }

    public HardcoverBook PublishHardcoverBook(int pagesCount)
    {
        BookBuilderException.ThrowIfNullOrEmpty(_name, "название");
        BookBuilderException.ThrowIfNullOrEmpty(_categories, "категории");
        BookBuilderException.ThrowIfNullOrEmpty(_genres, "жанры");
        BookBuilderException.ThrowIfNullOrEmpty(_authors, "авторы");
        BookBuilderException.ThrowIfNullOrEmpty(_illustrations, "иллюстрации");
        if (_publishingYear is 0)
        {
            throw new BookBuilderException("Для создания книги не достаёт параметра - год публикации");
        }

        if (pagesCount is 0)
        {
            throw new BookBuilderException("Нельзя опубликовать книгу без страниц");
        }

        return new HardcoverBook(
            _name,
            _publishingYear,
            _isbn,
            1,
            pagesCount,
            _categories,
            _genres,
            _illustrations,
            _annotation,
            [.._authors]
        );
    }

    public PaperbackBook PublishPaperbackBook(int pagesCount)
    {
        BookBuilderException.ThrowIfNullOrEmpty(_name, "название");
        BookBuilderException.ThrowIfNullOrEmpty(_categories, "категории");
        BookBuilderException.ThrowIfNullOrEmpty(_genres, "жанры");
        BookBuilderException.ThrowIfNullOrEmpty(_authors, "авторы");
        BookBuilderException.ThrowIfNullOrEmpty(_illustrations, "иллюстрации");
        if (_publishingYear is 0)
        {
            throw new BookBuilderException("Для создания книги не достаёт параметра - год публикации");
        }

        if (pagesCount is 0)
        {
            throw new BookBuilderException("Нельзя опубликовать книгу без страниц");
        }

        return new PaperbackBook(
            _name,
            _publishingYear,
            _isbn,
            1,
            _categories,
            _genres,
            pagesCount,
            _illustrations,
            _annotation,
            [.._authors]
        );
    }
    
    public Magazine PublishMagazine(int pagesCount)
    {
        BookBuilderException.ThrowIfNullOrEmpty(_name, "название");
        BookBuilderException.ThrowIfNullOrEmpty(_categories, "категории");
        BookBuilderException.ThrowIfNullOrEmpty(_genres, "жанры");
        BookBuilderException.ThrowIfNullOrEmpty(_authors, "авторы");
        BookBuilderException.ThrowIfNullOrEmpty(_illustrations, "иллюстрации");
        if (_publishingYear is 0)
        {
            throw new BookBuilderException("Для создания книги не достаёт параметра - год публикации");
        }

        if (pagesCount is 0)
        {
            throw new BookBuilderException("Нельзя опубликовать книгу без страниц");
        }

        return new Magazine(
            _name,
            _publishingYear,
            _isbn,
            1,
            _categories,
            _genres,
            pagesCount,
            _illustrations,
            [.._authors]
        );
    }
}

public class BookBuilderException(string message) : Exception(message)
{
    public static void ThrowIfNullOrEmpty(object? obj, string paramName)
    {
        if (obj is null or ICollection { Count: <= 0 })
        {
            throw new BookBuilderException($"Для создания книги не достаёт параметра - {paramName}");
        }
    }
}