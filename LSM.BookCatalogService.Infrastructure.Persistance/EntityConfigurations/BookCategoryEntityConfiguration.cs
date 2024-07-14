using LSM.BookCatalogService.Infrastructure.Persistance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LSM.BookCatalogService.Infrastructure.Persistance.EntityConfigurations;

public sealed class BookCategoryEntityConfiguration : IEntityTypeConfiguration<DatabaseBookCategory>
{
    public void Configure(EntityTypeBuilder<DatabaseBookCategory> builder)
    {
        builder.ToTable("book_category");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName("id");

        builder.HasIndex(c => c.Name)
            .IsUnique();
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnName("name");

        builder.HasMany(c => c.Books)
            .WithOne(b => b.Category)
            .HasForeignKey(b => b.CategoryId);
    }
}