namespace LSM.BookCatalogService.Domain.Entities.Images;

public sealed class Painting(
    byte[] content,
    string title
) : Portrait(content, title);