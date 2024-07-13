namespace LSM.BookCatalogService.Domain.Entities.Images;

public sealed class Illustration(
    byte[] content,
    string title
) : Image(content, title);