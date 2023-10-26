namespace ComputerRepair.Domain.Common.Errors;

public partial class Errors
{
    public static class Role
    {
        public static Error IdСantBeRepeated(string fieldValue) => new Error(
            code: "Role.IdСantBeRepeated",
            message: "Роль не может повторяться.",
            field: "roleId",
            fieldValue: fieldValue);
    }
}
