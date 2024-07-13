using LSM.BookCatalogService.Domain.Helpers;

namespace LSM.BookCatalogService.Domain.Entities;

public class PublishingHouse(int publisherCode, string name)
{
    public string Name { get; } = name;
    public int PublisherCode { get; } = publisherCode;

    public BookBuilder PublishBook(int countryCode, int uniqueBookCode)
        => new(countryCode, PublisherCode, uniqueBookCode);
}