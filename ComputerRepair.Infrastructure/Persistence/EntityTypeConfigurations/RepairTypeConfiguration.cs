using ComputerRepair.Domain.AggregateModels.OfficeAggregate.ValueObjects;
using ComputerRepair.Domain.AggregateModels.RepairTypeAggregate;
using ComputerRepair.Domain.AggregateModels.RepairTypeAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerRepair.Infrastructure.Persistence.EntityTypeConfigurations;

public sealed class RepairTypeConfiguration : IEntityTypeConfiguration<RepairType>
{
    public void Configure(EntityTypeBuilder<RepairType> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => RepairTypeId.Create(value));

        builder.Property(x => x.Title)
            .HasMaxLength(50)
            .IsRequired();

        builder.Ignore(x => x.DomainEvents);

        builder.HasIndex(x => x.Title).IsUnique();
    }
}
