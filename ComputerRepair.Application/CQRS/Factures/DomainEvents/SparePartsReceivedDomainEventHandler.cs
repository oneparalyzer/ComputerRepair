using ComputerRepair.Application.Common.Interfaces.Repositories;
using ComputerRepair.Domain.AggregateModels.FactureAggregate;
using ComputerRepair.Domain.AggregateModels.FactureAggregate.DomainEvents;
using ComputerRepair.Domain.AggregateModels.Warehouses;
using MediatR;

namespace ComputerRepair.Application.CQRS.Factures.DomainEvents;

public sealed class SparePartsReceivedDomainEventHandler : INotificationHandler<SparePartsReceivedDomainEvent>
{
    private readonly IUnitOfWork _unitOfWork;

    public SparePartsReceivedDomainEventHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(SparePartsReceivedDomainEvent domainEvent, CancellationToken cancellationToken)
    {
        Facture facture = domainEvent.Facture;

        
    }
}
