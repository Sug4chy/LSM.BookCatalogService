using Microsoft.EntityFrameworkCore;

namespace LSM.BookCatalogService.Infrastructure.Persistance;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    
}