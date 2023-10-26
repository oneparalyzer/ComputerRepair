using ComputerRepair.Domain.AggregateModels.FactureAggregate;
using ComputerRepair.Domain.AggregateModels.FactureAggregate.Entities;
using ComputerRepair.Domain.AggregateModels.OfficeAggregate;
using ComputerRepair.Domain.AggregateModels.PartnerAggregate;
using ComputerRepair.Domain.AggregateModels.RepairTypeAggregate;
using ComputerRepair.Domain.AggregateModels.SparePartAggregate;
using ComputerRepair.Domain.AggregateModels.SparePartAggregate.Enums;
using ComputerRepair.Domain.AggregateModels.WarehouseAggregate.Entities;
using ComputerRepair.Domain.AggregateModels.Warehouses;
using ComputerRepair.Infrastructure.Persistence.CustomIdentityEntity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ComputerRepair.Infrastructure.Persistence;

public sealed class ApplicationDbContext : IdentityDbContext<CustomIdentityUser, CustomIdentityRole, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Office> Offices { get; set; }
    public DbSet<RepairType> RepairTypes { get; set; }
    public DbSet<SparePart> SpareParts { get; set; }
    public DbSet<MeasureUnit> MeasureUnits { get; set; }
    public DbSet<Facture> Factures { get; set; }
    public DbSet<FacturePosition> FacturePositions { get; set; }
    public DbSet<Partner> Partners { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<SparePartWarehouse> SparePartWarehouses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
