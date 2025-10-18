using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProEvents.Domain.Entities;
using ProEvents.Infrastructure.Abstractions.EntitiesConfiguration;

namespace ProEvents.Infrastructure.EntitiesConfiguration;

public class SpeakerEntityConfiguration : BaseEntityConfiguration<Speaker>
{
    public override void Configure(EntityTypeBuilder<Speaker> builder)
    {
        base.Configure(builder);

        builder.ToTable("tb_speakers");

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.MiniCurriculum)
            .HasColumnName("mini_curriculum")
            .HasMaxLength(2000);

        builder.Property(x => x.ImageURL)
            .HasColumnName("image_url")
            .HasMaxLength(255);

        builder.Property(x => x.Phone)
            .HasColumnName("phone")
            .HasMaxLength(20);

        builder.Property(x => x.Email)
            .HasColumnName("email")
            .HasMaxLength(100);
        
        builder.HasMany(x => x.SocialMedias)
            .WithOne(sm => sm.Speaker)
            .HasForeignKey(sm => sm.SpeakerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.EventSpeakers)
            .WithOne(es => es.Speaker)
            .HasForeignKey(es => es.SpeakerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
