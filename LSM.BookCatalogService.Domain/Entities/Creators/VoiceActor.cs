using LSM.BookCatalogService.Domain.Entities.Books;
using LSM.BookCatalogService.Domain.ValueObjects;

namespace LSM.BookCatalogService.Domain.Entities.Creators;

public sealed class VoiceActor(
    string name,
    DateTime birthDate,
    Country placeOfBirth,
    ContactInformation? contactInformation = null,
    DateTime? deathDate = null,
    string? shortBiography = null
) : Creator(name, birthDate, placeOfBirth, contactInformation, deathDate, shortBiography)
{
    private readonly List<AudioBook> _audioBooks = [];

    public IReadOnlyList<AudioBook> AudioBooks => _audioBooks.AsReadOnly();

    public void AddAudioBook(AudioBook audioBook)
    {
        ArgumentNullException.ThrowIfNull(audioBook, nameof(audioBook));
        
        _audioBooks.Add(audioBook);
    }
}