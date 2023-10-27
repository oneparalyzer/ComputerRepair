using ComputerRepair.Domain.AggregateModels.RepairTypeAggregate.ValueObjects;
using ComputerRepair.Domain.AggregateModels.SparePartAggregate;
using ComputerRepair.Domain.AggregateModels.SparePartAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerRepair.Infrastructure.Persistence.EntityTypeConfigurations;

public sealed class SparePartConfiguration : IEntityTypeConfiguration<SparePart>
{
    public void Configure(EntityTypeBuilder<SparePart> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => SparePartId.Create(value));

        builder.Property(x => x.Title).HasMaxLength(50).IsRequired();

        builder.Ignore(x => x.DomainEvents);

        builder.HasIndex(x => x.Title).IsUnique();

        builder.HasOne(x => x.MeasureUnit).WithMany();
    }
}
