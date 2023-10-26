namespace ComputerRepair.Domain.Common.Errors;

public partial class Errors
{
    public static class Office
    {
        public static Error AlreadyExistByTitle(string fieldValue) => new Error(
            code: "Office.AlreadyExistByTitle",
            message: "Офис с таким названием уже существует.",
            field: "title",
            fieldValue: fieldValue);

        public static Error NotFoundById(string fieldValue) => new Error(
            code: "Office.NotFoundById",
            message: "Офис не найден.",
            field: "officeId",
            fieldValue: fieldValue);
    }
}
