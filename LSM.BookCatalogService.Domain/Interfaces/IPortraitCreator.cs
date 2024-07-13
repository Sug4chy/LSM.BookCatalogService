using LSM.BookCatalogService.Domain.Entities.Images;

namespace LSM.BookCatalogService.Domain.Interfaces;

public interface IPortraitCreator
{
    Portrait CreatePortrait(byte[] content, string title);
}