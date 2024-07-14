using LSM.BookCatalogService.Infrastructure.Persistance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LSM.BookCatalogService.Infrastructure.Persistance.EntityConfigurations;

public sealed class PublishingHouseEntityConfiguration : IEntityTypeConfiguration<DatabasePublishingHouse>
{
    public void Configure(EntityTypeBuilder<DatabasePublishingHouse> builder)
    {
        builder.ToTable("publishing_house");

        builder.HasKey(ph => ph.Id);
        builder.Property(ph => ph.Id)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName("id");

        builder.HasIndex(ph => ph.Name)
            .IsUnique();
        builder.Property(ph => ph.Name)
            .IsRequired()
            .HasMaxLength(250)
            .HasColumnName("name");

        builder.HasIndex(ph => ph.IsbnCode)
            .IsUnique();
        builder.Property(ph => ph.IsbnCode)
            .IsRequired()
            .HasMaxLength(13)
            .HasColumnName("isbn_code");

        builder.HasMany(ph => ph.Books)
            .WithOne(b => b.PublishingHouse)
            .HasForeignKey(b => b.PublishingHouseId);
    }
}