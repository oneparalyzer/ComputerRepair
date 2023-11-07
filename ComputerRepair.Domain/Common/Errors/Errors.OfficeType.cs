namespace ComputerRepair.Domain.Common.Errors;

public partial class Errors
{
    public static class OfficeType
    {
        public static Error NotFoundById(string fieldValue) => new Error(
            code: "OfficeType.NotFoundById",
            message: "Тип офиса не найден.",
            field: "officeTypeId",
            fieldValue: fieldValue);
    }
}
