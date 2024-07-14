using LSM.BookCatalogService.Infrastructure.Persistance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LSM.BookCatalogService.Infrastructure.Persistance.EntityConfigurations;

public sealed class IllustratorEntityConfiguration : IEntityTypeConfiguration<DatabaseIllustrator>
{
    public void Configure(EntityTypeBuilder<DatabaseIllustrator> builder)
    {
        builder.ToTable("illustrator");

        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName("id");

        builder.HasIndex(i => i.FullName)
            .IsUnique();
        builder.Property(i => i.FullName)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnName("full_name");

        builder.Property(i => i.BirthDate)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName("birth_date");
        
        builder.Property(i => i.Email)
            .HasMaxLength(100)
            .HasColumnName("email");

        builder.Property(i => i.ContactInformation)
            .HasColumnType("jsonb")
            .HasColumnName("contact_information");

        builder.Property(i => i.DeathDate)
            .ValueGeneratedNever()
            .HasColumnName("death_date");

        builder.Property(i => i.ShortBiography)
            .HasMaxLength(250)
            .HasColumnName("short_biography");

        builder.HasOne(i => i.Country)
            .WithMany(c => c.Illustrators)
            .HasForeignKey(i => i.CountryId);
        builder.Property(i => i.CountryId)
            .IsRequired()
            .HasColumnName("country_id");

        builder.HasMany(i => i.Illustrations)
            .WithOne(i => i.Illustrator)
            .HasForeignKey(i => i.IllustratorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}