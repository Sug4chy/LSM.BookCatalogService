using LSM.BookCatalogService.Infrastructure.Persistance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LSM.BookCatalogService.Infrastructure.Persistance.EntityConfigurations;

public sealed class BookEntityConfiguration : IEntityTypeConfiguration<DatabaseBook>
{
    public void Configure(EntityTypeBuilder<DatabaseBook> builder)
    {
        builder.ToTable("book");

        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id)
            .IsRequired()
            .ValueGeneratedNever()
            .HasColumnName("id");

        builder.HasIndex(b => b.Name)
            .IsUnique();
        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(128)
            .HasColumnName("name");

        builder.Property(b => b.PublishingYear)
            .IsRequired()
            .HasColumnName("publishing_year");

        builder.HasIndex(b => b.Isbn)
            .IsUnique();
        builder.Property(b => b.Isbn)
            .IsRequired()
            .HasMaxLength(13)
            .HasColumnName("isbn");

        builder.Property(b => b.IsAvailable)
            .IsRequired()
            .HasColumnName("is_available");

        builder.Property(b => b.Annotation)
            .HasMaxLength(250)
            .HasColumnName("annotation");

        builder.Property(b => b.Discriminator)
            .IsRequired()
            .HasColumnName("discriminator");

        builder.Property(b => b.AvailableCount)
            .HasColumnName("available_count");

        builder.Property(b => b.CountInLibrary)
            .HasColumnName("count_in_library");

        builder.Property(b => b.PagesCount)
            .HasColumnName("pages_count");

        builder.Property(b => b.FilePath)
            .HasMaxLength(short.MaxValue)
            .HasColumnName("file_path");

        builder.HasOne(b => b.VoiceActor)
            .WithMany(b => b.AudioBooks)
            .HasForeignKey(b => b.VoiceActorId);
        builder.Property(b => b.VoiceActorId)
            .HasColumnName("voice_actor_id");

        builder.HasMany(b => b.Illustrations)
            .WithOne(i => i.Book)
            .HasForeignKey(i => i.BookId);

        builder.HasMany(b => b.Categories)
            .WithOne(c => c.Book)
            .HasForeignKey(c => c.BookId);

        builder.HasMany(b => b.Genres)
            .WithOne(g => g.Book)
            .HasForeignKey(g => g.BookId);

        builder.HasOne(b => b.PublishingHouse)
            .WithMany(ph => ph.Books)
            .HasForeignKey(b => b.PublishingHouseId)
            .IsRequired();

        builder.HasMany(b => b.Authors)
            .WithOne(ab => ab.Book)
            .HasForeignKey(ab => ab.BookId);
    }
}