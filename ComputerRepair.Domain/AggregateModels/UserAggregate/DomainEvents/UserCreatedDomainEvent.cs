using ComputerRepair.Domain.AggregateModels.UserAggregate.ValueObjects;
using ComputerRepair.Domain.SeedWorks;

namespace ComputerRepair.Domain.AggregateModels.UserAggregate.DomainEvents;

public record UserCreatedDomainEvent(User User) : IDomainEvent;
