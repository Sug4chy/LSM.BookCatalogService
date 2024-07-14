using LSM.BookCatalogService.Infrastructure.Persistance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LSM.BookCatalogService.Infrastructure.Persistance.EntityConfigurations;

public sealed class CountryEntityConfiguration : IEntityTypeConfiguration<DatabaseCountry>
{
    public void Configure(EntityTypeBuilder<DatabaseCountry> builder)
    {
        builder.ToTable("country");

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

        builder.HasMany(c => c.Authors)
            .WithOne(a => a.Country)
            .HasForeignKey(a => a.CountryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.VoiceActors)
            .WithOne(va => va.Country)
            .HasForeignKey(va => va.CountryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Illustrators)
            .WithOne(i => i.Country)
            .HasForeignKey(i => i.CountryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.PortraitCreators)
            .WithOne(pc => pc.Country)
            .HasForeignKey(pc => pc.CountryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}