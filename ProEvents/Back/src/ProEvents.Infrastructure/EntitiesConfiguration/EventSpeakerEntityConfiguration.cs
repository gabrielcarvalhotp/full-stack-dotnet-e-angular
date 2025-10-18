using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProEvents.Domain.Entities;

namespace ProEvents.Infrastructure.EntitiesConfiguration;

public class EventSpeakerEntityConfiguration : IEntityTypeConfiguration<EventSpeaker>
{
    public void Configure(EntityTypeBuilder<EventSpeaker> builder)
    {
        builder.ToTable("tb_event_speakers");
        
        builder.HasKey(es => new { es.EventId, es.SpeakerId });

        builder.Property(es => es.EventId)
            .HasColumnName("event_id")
            .IsRequired();

        builder.Property(es => es.SpeakerId)
            .HasColumnName("speaker_id")
            .IsRequired();
        
        builder.HasOne(es => es.Event)
            .WithMany(e => e.EventSpeakers)
            .HasForeignKey(es => es.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(es => es.Speaker)
            .WithMany(s => s.EventSpeakers)
            .HasForeignKey(es => es.SpeakerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
