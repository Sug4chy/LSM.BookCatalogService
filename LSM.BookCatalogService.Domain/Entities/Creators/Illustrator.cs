using LSM.BookCatalogService.Domain.Entities.Images;
using LSM.BookCatalogService.Domain.ValueObjects;

namespace LSM.BookCatalogService.Domain.Entities.Creators;

public sealed class Illustrator(
    string name,
    DateTime birthDate,
    Country placeOfBirth,
    ContactInformation? contactInformation = null,
    DateTime? deathDate = null,
    string? shortBiography = null
) : Creator(name, birthDate, placeOfBirth, contactInformation, deathDate, shortBiography)
{
    private readonly List<Illustration> _illustrations = [];

    public IReadOnlyList<Illustration> Illustrations => _illustrations.AsReadOnly();
    
    public Illustration DrawIllustration(byte[] content, string title)
    {
        var illustration = new Illustration(content, title);
        _illustrations.Add(illustration);
        return illustration;
    }
}