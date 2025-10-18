using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProEvents.Domain.Entities;
using ProEvents.Infrastructure.Abstractions.EntitiesConfiguration;

namespace ProEvents.Infrastructure.EntitiesConfiguration;

public class BatchEntityConfiguration : BaseEntityConfiguration<Batch>
{
    public override void Configure(EntityTypeBuilder<Batch> builder)
    {
        base.Configure(builder);

        builder.ToTable("tb_batches");

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Price)
            .HasColumnName("price")
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(x => x.StartDate)
            .HasColumnName("start_date");

        builder.Property(x => x.EndDate)
            .HasColumnName("end_date");

        builder.Property(x => x.Quantity)
            .HasColumnName("quantity")
            .IsRequired();

        builder.Property(x => x.EventId)
            .HasColumnName("event_id")
            .IsRequired();

        builder.HasOne(x => x.Event)
            .WithMany(e => e.Batches)
            .HasForeignKey(x => x.EventId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
