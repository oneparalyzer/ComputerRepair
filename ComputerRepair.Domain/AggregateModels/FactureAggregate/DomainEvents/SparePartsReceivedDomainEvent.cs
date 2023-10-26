using ComputerRepair.Domain.SeedWorks;

namespace ComputerRepair.Domain.AggregateModels.FactureAggregate.DomainEvents;

public record SparePartsReceivedDomainEvent(Facture Facture) : IDomainEvent;
