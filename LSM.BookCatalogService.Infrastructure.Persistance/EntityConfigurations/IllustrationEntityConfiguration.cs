using LSM.BookCatalogService.Infrastructure.Persistance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LSM.BookCatalogService.Infrastructure.Persistance.EntityConfigurations;

public sealed class IllustrationEntityConfiguration : IEntityTypeConfiguration<DatabaseIllustration>
{
    public void Configure(EntityTypeBuilder<DatabaseIllustration> builder)
    {
        builder.ToTable("illustration");

        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName("id");

        builder.HasIndex(i => i.Title)
            .IsUnique();
        builder.Property(i => i.Title)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnName("title");

        builder.HasIndex(i => i.FilePath)
            .IsUnique();
        builder.Property(i => i.FilePath)
            .IsRequired()
            .HasMaxLength(short.MaxValue)
            .HasColumnName("file_path");

        builder.HasOne(i => i.Book)
            .WithMany(b => b.Illustrations)
            .HasForeignKey(i => i.BookId);
        builder.Property(i => i.BookId)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName("book_id");

        builder.HasOne(i => i.Illustrator)
            .WithMany(i => i.Illustrations)
            .HasForeignKey(i => i.IllustratorId);
        builder.Property(i => i.IllustratorId)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName("illustrator_id");
    }
}