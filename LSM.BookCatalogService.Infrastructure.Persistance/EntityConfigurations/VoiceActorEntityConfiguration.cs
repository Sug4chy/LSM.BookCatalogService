using LSM.BookCatalogService.Infrastructure.Persistance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LSM.BookCatalogService.Infrastructure.Persistance.EntityConfigurations;

public sealed class VoiceActorEntityConfiguration : IEntityTypeConfiguration<DatabaseVoiceActor>
{
    public void Configure(EntityTypeBuilder<DatabaseVoiceActor> builder)
    {
        builder.ToTable("voice_actor");

        builder.HasKey(vc => vc.Id);
        builder.Property(vc => vc.Id)
            .IsRequired()
            .ValueGeneratedNever()
            .HasColumnName("id");

        builder.HasIndex(vc => vc.FullName)
            .IsUnique();
        builder.Property(vc => vc.FullName)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnName("full_name");

        builder.Property(vc => vc.BirthDate)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName("birth_date");

        builder.Property(vc => vc.Email)
            .HasMaxLength(100)
            .HasColumnName("email");

        builder.Property(vc => vc.ContactInformation)
            .HasColumnType("jsonb")
            .HasColumnName("contact_information");

        builder.Property(vc => vc.DeathDate)
            .ValueGeneratedNever()
            .HasColumnName("death_date");

        builder.Property(vc => vc.ShortBiography)
            .HasMaxLength(250)
            .HasColumnName("short_biography");
        
        builder.HasOne(vc => vc.Country)
            .WithMany(c => c.VoiceActors)
            .HasForeignKey(vc => vc.CountryId);
        builder.Property(vc => vc.CountryId)
            .IsRequired()
            .ValueGeneratedNever()
            .HasColumnName("country_id");

        builder.HasMany(vc => vc.AudioBooks)
            .WithOne(b => b.VoiceActor)
            .HasForeignKey(b => b.VoiceActorId);
    }
}