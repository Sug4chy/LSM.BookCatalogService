using LSM.BookCatalogService.Infrastructure.Persistance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LSM.BookCatalogService.Infrastructure.Persistance.EntityConfigurations;

public sealed class PortraitCreatorEntityConfiguration : IEntityTypeConfiguration<DatabasePortraitCreator>
{
    public void Configure(EntityTypeBuilder<DatabasePortraitCreator> builder)
    {
        builder.ToTable("portrait_creator");
        
        builder.HasKey(pc => pc.Id);
        builder.Property(pc => pc.Id)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName("id");

        builder.HasIndex(pc => pc.FullName)
            .IsUnique();
        builder.Property(pc => pc.FullName)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnName("full_name");

        builder.Property(pc => pc.BirthDate)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName("birth_date");
        
        builder.Property(pc => pc.Email)
            .HasMaxLength(100)
            .HasColumnName("email");

        builder.Property(pc => pc.ContactInformation)
            .HasColumnType("jsonb")
            .HasColumnName("contact_information");

        builder.Property(pc => pc.DeathDate)
            .ValueGeneratedNever()
            .HasColumnName("death_date");

        builder.Property(pc => pc.ShortBiography)
            .HasMaxLength(250)
            .HasColumnName("short_biography");

        builder.HasOne(pc => pc.Country)
            .WithMany(c => c.PortraitCreators)
            .HasForeignKey(pc => pc.CountryId);
        builder.Property(pc => pc.CountryId)
            .IsRequired()
            .HasColumnName("country_id");

        builder.HasMany(pc => pc.Portraits)
            .WithOne(p => p.Creator)
            .HasForeignKey(p => p.CreatorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}