namespace LSM.BookCatalogService.Domain.Entities.Images;

public abstract class Image
{
    public byte[] Content { get; }
    public string Title { get; }

    protected Image(byte[] content, string title)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title, nameof(title));
        if (content is not { Length: > 0 })
        {
            throw new ArgumentException("Изображение не может быть пустым", nameof(content));
        }

        Content = content;
        Title = title;
    }
}