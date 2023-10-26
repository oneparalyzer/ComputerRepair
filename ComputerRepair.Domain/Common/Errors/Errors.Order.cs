namespace ComputerRepair.Domain.Common.Errors;

public partial class Errors
{
    public static class Order
    {
        public static Error AlreadyСompleted => new Error(
            code: "Order.AlreadyСompleted",
            message: "Заказ уже выполнен.");

        public static Error AlreadyAccepted => new Error(
            code: "Order.AlreadyComplete",
            message: "Заказ уже принят к работе.");

        public static Error AlreadyMoneyBack => new Error(
            code: "Order.AlreadyMoneyBack",
            message: "Заказ уже имеет статус возврата денег.");

        public static Error AlreadyСorrection => new Error(
            code: "Order.AlreadyСorrection",
            message: "Заказ уже на исправлении.");
    }
}
