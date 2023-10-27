using ComputerRepair.Domain.AggregateModels.OfficeAggregate;
using ComputerRepair.Domain.AggregateModels.OfficeAggregate.ValueObjects;
using ComputerRepair.Domain.AggregateModels.RepairTypeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerRepair.Infrastructure.Persistence.EntityTypeConfigurations;

public sealed class OfficeConfiguration : IEntityTypeConfiguration<Office>
{
    public void Configure(EntityTypeBuilder<Office> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => OfficeId.Create(value));

        builder.Property(x => x.Title)
            .HasMaxLength(50)
            .IsRequired();

        builder.OwnsOne(x => x.Address)
            .Property(x => x.Region)
            .HasMaxLength(50)
            .IsRequired();

        builder.OwnsOne(x => x.Address)
            .Property(x => x.City)
            .HasMaxLength(50)
            .IsRequired();

        builder.OwnsOne(x => x.Address)
            .Property(x => x.Street)
            .HasMaxLength(50)
            .IsRequired();

        builder.OwnsOne(x => x.Address)
            .Property(x => x.Home)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(x => x.Title).IsUnique();

        builder.HasMany<RepairType>()
            .WithOne()
            .HasForeignKey(x => x.OfficeId);


        //Если ошибка добавить конкретный OfficeTypeId в Office
        builder.HasOne(x => x.OfficeType).WithMany();

        builder.Ignore(x => x.DomainEvents);

        builder.HasIndex(x => x.Title).IsUnique();
    }
}
