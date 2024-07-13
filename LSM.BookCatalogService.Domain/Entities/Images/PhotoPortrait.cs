namespace LSM.BookCatalogService.Domain.Entities.Images;

public sealed class PhotoPortrait(
    byte[] content,
    string title
) : Portrait(content, title);