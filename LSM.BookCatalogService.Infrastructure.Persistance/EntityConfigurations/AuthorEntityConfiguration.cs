using LSM.BookCatalogService.Infrastructure.Persistance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LSM.BookCatalogService.Infrastructure.Persistance.EntityConfigurations;

public sealed class AuthorEntityConfiguration : IEntityTypeConfiguration<DatabaseAuthor>
{
    public void Configure(EntityTypeBuilder<DatabaseAuthor> builder)
    {
        builder.ToTable("author");

        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id)
            .IsRequired()
            .ValueGeneratedNever()
            .HasColumnName("id");

        builder.HasIndex(a => a.FullName)
            .IsUnique();
        builder.Property(a => a.FullName)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnName("full_name");

        builder.Property(a => a.BirthDate)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName("birth_date");

        builder.Property(a => a.Email)
            .HasMaxLength(100)
            .HasColumnName("email");

        builder.Property(a => a.ContactInformation)
            .HasColumnType("jsonb")
            .HasColumnName("contact_information");

        builder.Property(a => a.DeathDate)
            .ValueGeneratedNever()
            .HasColumnName("death_date");

        builder.Property(a => a.ShortBiography)
            .HasMaxLength(250)
            .HasColumnName("short_biography");

        builder.HasMany(a => a.Books)
            .WithOne(ab => ab.Author)
            .HasForeignKey(ab => ab.AuthorId);

        builder.HasOne(a => a.Country)
            .WithMany(c => c.Authors)
            .HasForeignKey(a => a.CountryId);
        builder.Property(a => a.CountryId)
            .IsRequired()
            .ValueGeneratedNever()
            .HasColumnName("country_id");

        builder.HasOne(a => a.Portrait)
            .WithOne(p => p.Author)
            .HasForeignKey<DatabasePortrait>(p => p.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}