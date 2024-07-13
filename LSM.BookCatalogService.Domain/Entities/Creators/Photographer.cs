using LSM.BookCatalogService.Domain.Entities.Images;
using LSM.BookCatalogService.Domain.Interfaces;
using LSM.BookCatalogService.Domain.ValueObjects;

namespace LSM.BookCatalogService.Domain.Entities.Creators;

public sealed class Photographer(
    string name,
    DateTime birthDate,
    Country placeOfBirth,
    ContactInformation? contactInformation = null,
    DateTime? deathDate = null,
    string? shortBiography = null,
    Portrait? portrait = null
) : Creator(name, birthDate, placeOfBirth, contactInformation, deathDate, shortBiography, portrait), 
    IPortraitCreator
{
    private readonly List<PhotoPortrait> _photos = [];

    public IReadOnlyList<PhotoPortrait> Photos => _photos.AsReadOnly();
    
    public Portrait CreatePortrait(byte[] content, string title)
    {
        var photo = new PhotoPortrait(content, title);
        _photos.Add(photo);
        return photo;
    }
}