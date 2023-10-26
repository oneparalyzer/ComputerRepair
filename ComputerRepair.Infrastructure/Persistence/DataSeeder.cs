using ComputerRepair.Domain.AggregateModels.SparePartAggregate.Enums;
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
    }
}
