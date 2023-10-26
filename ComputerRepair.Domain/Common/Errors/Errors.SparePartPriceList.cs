namespace ComputerRepair.Domain.Common.Errors;

public partial class Errors
{
    public static class SparePartPriceList
    {
        public static Error PositionIsNotUnique(string fieldValue) => new Error(
            code: "SparePartPriceList.PositionIsNotUnique",
            message: "Позиция не уникальна.",
            field: "positionId",
            fieldValue: fieldValue);   
    }
}
