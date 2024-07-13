using LSM.BookCatalogService.Domain.Entities.Images;
using LSM.BookCatalogService.Domain.ValueObjects;

namespace LSM.BookCatalogService.Domain.Entities.Creators;

public abstract class Creator
{
    public string Name { get; }
    public DateTime BirthDate { get; }
    public int BirthYear => BirthDate.Year;
    public DateTime? DeathDate { get; }
    public int? DeathYear => DeathDate?.Year;
    public Country PlaceOfBirth { get; }
    public ContactInformation? ContactInformation { get; }
    public string? ShortBiography { get; }
    public Portrait? Portrait { get; }
    
    protected Creator(
        string name,
        DateTime birthDate, 
        Country placeOfBirth, 
        ContactInformation? contactInformation = null, 
        DateTime? deathDate = null,
        string? shortBiography = null,
        Portrait? portrait = null
    )
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
        if (deathDate <= birthDate)
        {
            throw new ArgumentException("Дата смерти должна быть позже даты рождения", nameof(deathDate));
        }

        Name = name;
        BirthDate = birthDate;
        PlaceOfBirth = placeOfBirth;
        ContactInformation = contactInformation;
        DeathDate = deathDate;
        ShortBiography = shortBiography;
        Portrait = portrait;
    }
}