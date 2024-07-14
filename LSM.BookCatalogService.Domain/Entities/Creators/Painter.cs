using LSM.BookCatalogService.Domain.Entities.Images;
using LSM.BookCatalogService.Domain.Interfaces;
using LSM.BookCatalogService.Domain.ValueObjects;

namespace LSM.BookCatalogService.Domain.Entities.Creators;

public sealed class Painter(
    string name,
    DateTime birthDate,
    Country placeOfBirth,
    ContactInformation? contactInformation = null,
    DateTime? deathDate = null,
    string? shortBiography = null
) : Creator(name, birthDate, placeOfBirth, contactInformation, deathDate, shortBiography), 
    IPortraitCreator
{
    private readonly List<Painting> _paintings = [];

    public IReadOnlyList<Painting> Paintings => _paintings.AsReadOnly();
    
    public Portrait CreatePortrait(byte[] content, string title)
    {
        var painting = new Painting(content, title);
        _paintings.Add(painting);
        return painting;
    }
}