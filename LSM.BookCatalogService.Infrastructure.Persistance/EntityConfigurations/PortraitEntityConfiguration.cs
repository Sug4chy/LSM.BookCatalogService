using LSM.BookCatalogService.Infrastructure.Persistance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LSM.BookCatalogService.Infrastructure.Persistance.EntityConfigurations;

public sealed class PortraitEntityConfiguration : IEntityTypeConfiguration<DatabasePortrait>
{
    public void Configure(EntityTypeBuilder<DatabasePortrait> builder)
    {
        builder.ToTable("portrait");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .IsRequired()
            .ValueGeneratedNever()
            .HasColumnName("id");

        builder.HasIndex(p => p.Title)
            .IsUnique();
        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnName("title");

        builder.HasIndex(p => p.FilePath)
            .IsUnique();
        builder.Property(p => p.FilePath)
            .IsRequired()
            .HasMaxLength(short.MaxValue)
            .HasColumnName("file_path");

        builder.Property(p => p.Discriminator)
            .IsRequired()
            .HasColumnName("discriminator");

        builder.HasOne(p => p.Author)
            .WithOne(a => a.Portrait)
            .HasForeignKey<DatabasePortrait>(p => p.AuthorId);
        builder.Property(p => p.AuthorId)
            .IsRequired()
            .ValueGeneratedNever()
            .HasColumnName("author_id");

        builder.HasOne(p => p.Creator)
            .WithMany(c => c.Portraits)
            .HasForeignKey(p => p.CreatorId);
        builder.Property(p => p.CreatorId)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName("creator_id");
    }
}