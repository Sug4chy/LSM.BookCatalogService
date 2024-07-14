namespace LSM.BookCatalogService.Infrastructure.Persistance.Models.Discriminators;

public enum DatabaseBookDiscriminator
{
    HardcoverBook = 0,
    PaperbackBook = 1,
    Magazine = 2,
    EBook = 3,
    AudioBook = 4
}