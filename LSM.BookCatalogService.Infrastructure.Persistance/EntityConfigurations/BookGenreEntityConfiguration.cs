using LSM.BookCatalogService.Infrastructure.Persistance.Models.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LSM.BookCatalogService.Infrastructure.Persistance.EntityConfigurations;

public sealed class BookGenreEntityConfiguration : IEntityTypeConfiguration<DatabaseBookGenre>
{
    public void Configure(EntityTypeBuilder<DatabaseBookGenre> builder)
    {
        builder.ToTable("book_genre");

        builder.HasKey(nameof(DatabaseBookGenre.BookId), nameof(DatabaseBookGenre.GenreId));

        builder.HasOne(bg => bg.Book)
            .WithMany(b => b.Genres)
            .HasForeignKey(bg => bg.BookId);
        builder.Property(bg => bg.BookId)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName("book_id");

        builder.HasOne(bg => bg.Genre)
            .WithMany(g => g.Books)
            .HasForeignKey(bg => bg.GenreId);
        builder.Property(bg => bg.GenreId)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName("genre_id");
    }
}