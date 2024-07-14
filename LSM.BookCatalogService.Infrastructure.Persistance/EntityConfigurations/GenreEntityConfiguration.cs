using LSM.BookCatalogService.Infrastructure.Persistance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LSM.BookCatalogService.Infrastructure.Persistance.EntityConfigurations;

public sealed class GenreEntityConfiguration : IEntityTypeConfiguration<DatabaseGenre>
{
    public void Configure(EntityTypeBuilder<DatabaseGenre> builder)
    {
        builder.ToTable("genre");

        builder.HasKey(g => g.Id);
        builder.Property(g => g.Id)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName("id");

        builder.HasIndex(g => g.Name)
            .IsUnique();
        builder.Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("name");

        builder.HasMany(g => g.Books)
            .WithOne(b => b.Genre)
            .HasForeignKey(b => b.GenreId);
    }
}