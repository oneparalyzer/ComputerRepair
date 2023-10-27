using ComputerRepair.Domain.AggregateModels.EmployeeAggregate.ValueObjects;
using ComputerRepair.Domain.AggregateModels.OfficeAggregate.ValueObjects;
using ComputerRepair.Domain.AggregateModels.UserAggregate.ValueObjects;
using ComputerRepair.Domain.SeedWorks;

namespace ComputerRepair.Domain.AggregateModels.EmployeeAggregate;

public sealed class Employee : AggregateRoot<EmployeeId>
{
    private Employee(EmployeeId id) : base(id) { }

    private Employee(EmployeeId id, FullName fullName, DateTime birthDate, OfficeId officeId, UserId userId) : base(id)
    {
        FullName = fullName;
        BirthDate = birthDate;
        OfficeId = officeId;
        UserId = userId;
    }

    public FullName FullName { get; private set; }
    public DateTime BirthDate { get; private set; }
    public OfficeId OfficeId { get; private set; }
    public UserId UserId { get; private set; }

    public static Employee Create(FullName fullName, DateTime birthDate, OfficeId officeId, UserId userId)
    {
        return new Employee(EmployeeId.Create(), fullName, birthDate, officeId, userId);
    }
}
