using LSM.BookCatalogService.Infrastructure.Persistance.Models.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LSM.BookCatalogService.Infrastructure.Persistance.EntityConfigurations;

public sealed class AuthorBookEntityConfiguration : IEntityTypeConfiguration<DatabaseAuthorBook>
{
    public void Configure(EntityTypeBuilder<DatabaseAuthorBook> builder)
    {
        builder.ToTable("author_book");

        builder.HasKey(nameof(DatabaseAuthorBook.BookId), nameof(DatabaseAuthorBook.AuthorId));
        
        builder.HasOne(ab => ab.Book)
            .WithMany(b => b.Authors)
            .HasForeignKey(ab => ab.BookId);
        builder.Property(ab => ab.BookId)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName("book_id");

        builder.HasOne(ab => ab.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(ab => ab.AuthorId);
        builder.Property(ab => ab.AuthorId)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName("author_id");
    }
}