namespace LSM.BookCatalogService.Domain.Entities.Images;

public abstract class Portrait(
    byte[] content,
    string title
) : Image(content, title);