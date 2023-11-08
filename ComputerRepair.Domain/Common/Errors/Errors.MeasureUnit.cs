namespace ComputerRepair.Domain.Common.Errors;

public partial class Errors
{
    public static class MeasureUnit
    {
        public static Error NotFoundById(string fieldValue) => new Error(
            code: "MeasureUnit.NotFoundById",
            message: "Еденица измерения не найдена.",
            field: "measureUnitId",
            fieldValue: fieldValue);
    }
}
