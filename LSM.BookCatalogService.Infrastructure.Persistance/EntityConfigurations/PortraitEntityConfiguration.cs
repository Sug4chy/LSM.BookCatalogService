using LSM.BookCatalogService.Infrastructure.Persistance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LSM.BookCatalogService.Infrastructure.Persistance.EntityConfigurations;

public sealed class PortraitEntityConfiguration : IEntityTypeConfiguration<DatabasePortrait>
{
    public void Configure(EntityTypeBuilder<DatabasePortrait> builder)
    {
        
    }
}