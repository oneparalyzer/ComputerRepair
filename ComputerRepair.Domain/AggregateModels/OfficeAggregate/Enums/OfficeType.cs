using ComputerRepair.Domain.SeedWorks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ComputerRepair.Domain.AggregateModels.OfficeAggregate.Enums;

public sealed class OfficeType : Enumeration
{
    private OfficeType(int id, string name) : base(id, name) { }

    public static OfficeType ForManagement = new (1, "Для управления");
    public static OfficeType ForProvideServices = new(2, "Для предоставления услуг");
}
