namespace ComputerRepair.Domain.Common.Errors;

public partial class Errors
{
    public static class SparePart
    {
        public static Error AlreadyExistByTitle(string fieldValue) => new Error(
            code: "SparePart.AlreadyExistByTitle",
            message: "Зап-часть с таким названием уже существует.",
            field: "title",
            fieldValue: fieldValue);

        public static Error NotFoundById(string fieldValue) => new Error(
            code: "SparePart.NotFoundById",
            message: "Зап-часть не найдена.",
            field: "warehouseId",
            fieldValue: fieldValue);

        public static Error IdСantBeRepeated(string fieldValue) => new Error(
            code: "SparePart.IdСantBeRepeated",
            message: "Зап. части не может повторяться.",
            field: "sparePartId",
            fieldValue: fieldValue);
    }
}
