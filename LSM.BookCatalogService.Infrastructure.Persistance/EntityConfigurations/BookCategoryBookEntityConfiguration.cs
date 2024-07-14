using LSM.BookCatalogService.Infrastructure.Persistance.Models.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LSM.BookCatalogService.Infrastructure.Persistance.EntityConfigurations;

public sealed class BookCategoryBookEntityConfiguration : IEntityTypeConfiguration<DatabaseBookCategoryBook>
{
    public void Configure(EntityTypeBuilder<DatabaseBookCategoryBook> builder)
    {
        builder.ToTable("book_category_book");

        builder.HasKey(nameof(DatabaseBookCategoryBook.BookId), nameof(DatabaseBookCategoryBook.CategoryId));

        builder.HasOne(bcb => bcb.Book)
            .WithMany(b => b.Categories)
            .HasForeignKey(bcb => bcb.BookId);
        builder.Property(bcb => bcb.BookId)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName("book_id");

        builder.HasOne(bcb => bcb.Category)
            .WithMany(c => c.Books)
            .HasForeignKey(bcb => bcb.CategoryId);
        builder.Property(bcb => bcb.CategoryId)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName("category_id");
    }
}