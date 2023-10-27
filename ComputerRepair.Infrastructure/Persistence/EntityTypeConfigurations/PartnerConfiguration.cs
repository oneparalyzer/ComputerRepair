using ComputerRepair.Domain.AggregateModels.EmployeeAggregate.ValueObjects;
using ComputerRepair.Domain.AggregateModels.PartnerAggregate;
using ComputerRepair.Domain.AggregateModels.PartnerAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerRepair.Infrastructure.Persistence.EntityTypeConfigurations;

public sealed class PartnerConfiguration : IEntityTypeConfiguration<Partner>
{
    public void Configure(EntityTypeBuilder<Partner> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => PartnerId.Create(value));

        builder.Property(x => x.Title).HasMaxLength(50).IsRequired();

        builder.HasIndex(x => x.Title).IsUnique();

        builder.Ignore(x => x.DomainEvents);
    }
}
