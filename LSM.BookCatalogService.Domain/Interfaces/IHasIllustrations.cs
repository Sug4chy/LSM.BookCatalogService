using LSM.BookCatalogService.Domain.Entities.Images;

namespace LSM.BookCatalogService.Domain.Interfaces;

public interface IHasIllustrations
{
    IReadOnlyList<Illustration> Illustrations { get; }
}