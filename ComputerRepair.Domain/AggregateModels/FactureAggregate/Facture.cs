using ComputerRepair.Domain.AggregateModels.FactureAggregate.DomainEvents;
using ComputerRepair.Domain.AggregateModels.FactureAggregate.Entities;
using ComputerRepair.Domain.AggregateModels.FactureAggregate.ValueObjects;
using ComputerRepair.Domain.AggregateModels.PartnerAggregate.ValueObjects;
using ComputerRepair.Domain.AggregateModels.RoleAggregate.ValueObjects;
using ComputerRepair.Domain.AggregateModels.SparePartAggregate.ValueObjects;
using ComputerRepair.Domain.AggregateModels.Warehouses.ValueObjects;
using ComputerRepair.Domain.Common.Errors;
using ComputerRepair.Domain.Common.OperationResults;
using ComputerRepair.Domain.SeedWorks;

namespace ComputerRepair.Domain.AggregateModels.FactureAggregate;

public sealed class Facture : AggregateRoot<FactureId>
{
    private readonly List<FacturePosition> _positions;

    private Facture(FactureId id) : base(id) { }

    private Facture(
        FactureId id, 
        List<FacturePosition> positions, 
        PartnerId partnerId,
        WarehouseId warehouseId) : base(id)
    {
        _positions = positions;
        PartnerId = partnerId;
        WarehouseId = warehouseId;
    }

    public PartnerId PartnerId { get; private set; }
    public WarehouseId WarehouseId { get; private set; }

    public IReadOnlyList<FacturePosition> Positions => _positions.AsReadOnly();

    public static Result<Facture> Create(
        List<FacturePosition> positions,
        PartnerId partnerId,
        WarehouseId warehouseId)
    {
        Result checkResult = CheckForExistenceFacturePositions(positions);
        
        if (!checkResult.IsSuccess)
        {
            return Result.Failure<Facture>(checkResult.Errors);
        }

        var facture = new Facture(
            FactureId.Create(),
            positions,
            partnerId,
            warehouseId);

        facture.AddDomainEvent(new SparePartsReceivedDomainEvent(facture));

        return Result.Success(facture);
    }

    private static Result CheckForExistenceFacturePositions(List<FacturePosition> facturePositions)
    {
        var errors = new List<Error>();
        var uniqueFacturePositions = new HashSet<SparePartId>();

        foreach (var facturePosition in facturePositions)
        {
            if (!uniqueFacturePositions.Add(facturePosition.SparePartId))
            {
                errors.Add(Errors.SparePart.IdСantBeRepeated(facturePosition.SparePartId.ToString()));
            }
        }

        if (errors.Any())
        {
            return Result.Failure(errors);
        }

        return Result.Success();
    }
}
