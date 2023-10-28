using ComputerRepair.Domain.AggregateModels.EmployeeAggregate;
using ComputerRepair.Domain.AggregateModels.EmployeeAggregate.ValueObjects;
using ComputerRepair.Domain.AggregateModels.OfficeAggregate;
using ComputerRepair.Domain.AggregateModels.OfficeAggregate.Enums;
using ComputerRepair.Domain.AggregateModels.OfficeAggregate.ValueObjects;
using ComputerRepair.Domain.AggregateModels.SparePartAggregate.Enums;
using ComputerRepair.Domain.AggregateModels.UserAggregate.ValueObjects;
using ComputerRepair.Infrastructure.Persistence.CustomIdentityEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ComputerRepair.Infrastructure.Persistence;

public static class DataSeeder
{
    public static void Seed(ModelBuilder builder)
    {
        builder.Entity<MeasureUnit>().HasData(new List<MeasureUnit>
        { 
            MeasureUnit.Piece
        });

        builder.Entity<OfficeType>().HasData(new List<OfficeType>
        {
            OfficeType.ForProvideServices, 
            OfficeType.ForManagement
        });
    }
}
