namespace ComputerRepair.Domain.Common.Errors;

public partial class Errors
{
    public static class RepairType
    {
        public static Error AlreadyExistByTitle(string fieldValue) => new Error(
            code: "Warehouse.AlreadyExistByTitle",
            message: "Склад с таким названием уже существует.",
            field: "title",
            fieldValue: fieldValue);

        public static Error NotFoundById(string fieldValue) => new Error(
            code: "Warehouse.NotFoundById",
            message: "Склад не найден.",
            field: "warehouseId",
            fieldValue: fieldValue);
    }
}
