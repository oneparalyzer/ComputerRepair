using ComputerRepair.Domain.AggregateModels.OfficeAggregate.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerRepair.Infrastructure.Persistence.EntityTypeConfigurations;

public sealed class OfficeTypeConfiguration : IEntityTypeConfiguration<OfficeType>
{
    public void Configure(EntityTypeBuilder<OfficeType> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(24).IsRequired();

        builder.HasIndex(x => x.Name).IsUnique();
    }
}
