using ComputerRepair.Domain.AggregateModels.EmployeeAggregate;
using ComputerRepair.Domain.AggregateModels.EmployeeAggregate.ValueObjects;
using ComputerRepair.Domain.AggregateModels.OfficeAggregate;
using ComputerRepair.Domain.AggregateModels.OfficeAggregate.ValueObjects;
using ComputerRepair.Domain.AggregateModels.UserAggregate;
using ComputerRepair.Domain.AggregateModels.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerRepair.Infrastructure.Persistence.EntityTypeConfigurations;

public sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => EmployeeId.Create(value));

        builder.OwnsOne(x => x.FullName)
            .Property(x => x.Surname)
            .HasMaxLength(50)
            .IsRequired();

        builder.OwnsOne(x => x.FullName)
            .Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.OwnsOne(x => x.FullName)
            .Property(x => x.Patronymic)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.BirthDate).IsRequired();

        builder.Property(x => x.UserId)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));

        builder.Property(x => x.OfficeId)
            .HasConversion(
                id => id.Value,
                value => OfficeId.Create(value));

        builder.HasOne<Office>().WithMany().HasForeignKey(x => x.OfficeId);

        builder.HasOne<User>().WithMany().HasForeignKey(x => x.UserId);

        builder.Ignore(x => x.DomainEvents);
    }
}
