using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProEvents.Domain.Entities;
using ProEvents.Infrastructure.Abstractions.EntitiesConfiguration;

namespace ProEvents.Infrastructure.EntitiesConfiguration;

public class SocialMediaEntityConfiguration : BaseEntityConfiguration<SocialMedia>
{
    public override void Configure(EntityTypeBuilder<SocialMedia> builder)
    {
        base.Configure(builder);

        builder.ToTable("tb_social_medias");

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.URL)
            .HasColumnName("url")
            .HasMaxLength(255);

        builder.Property(x => x.EventId)
            .HasColumnName("event_id");

        builder.Property(x => x.SpeakerId)
            .HasColumnName("speaker_id");
        
        builder.HasOne(x => x.Event)
            .WithMany(e => e.SocialMedias)
            .HasForeignKey(x => x.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Speaker)
            .WithMany(s => s.SocialMedias)
            .HasForeignKey(x => x.SpeakerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
