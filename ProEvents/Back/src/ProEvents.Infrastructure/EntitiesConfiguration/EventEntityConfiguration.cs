using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProEvents.Domain.Entities;
using ProEvents.Infrastructure.Abstractions.EntitiesConfiguration;

namespace ProEvents.Infrastructure.EntitiesConfiguration;

public class EventEntityConfiguration : BaseEntityConfiguration<Event>
{
    public override void Configure(EntityTypeBuilder<Event> builder)
    {
        base.Configure(builder);

        builder.ToTable("tb_events");

        builder.Property(x => x.Location)
            .HasColumnName("location")
            .HasMaxLength(120);

        builder.Property(x => x.EventDate)
            .HasColumnName("event_date");

        builder.Property(x => x.Theme)
            .HasColumnName("theme")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.NumberPeople)
            .HasColumnName("number_people")
            .IsRequired();

        builder.Property(x => x.ImageURL)
            .HasColumnName("image_url")
            .HasMaxLength(255);

        builder.Property(x => x.Phone)
            .HasColumnName("phone")
            .HasMaxLength(20);

        builder.Property(x => x.Email)
            .HasColumnName("email")
            .HasMaxLength(100);
        
        builder.HasMany(x => x.Batches)
            .WithOne(b => b.Event)
            .HasForeignKey(b => b.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.SocialMedias)
            .WithOne(s => s.Event)
            .HasForeignKey(s => s.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.EventSpeakers)
            .WithOne(es => es.Event)
            .HasForeignKey(es => es.EventId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
