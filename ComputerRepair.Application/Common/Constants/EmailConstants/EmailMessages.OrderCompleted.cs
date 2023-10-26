namespace ComputerRepair.Application.Common.Constants.EmailConstants;

public partial class EmailMessages
{
    public static class OrderCompleted
    {
        public static string Subject => "Заказ готов.";
        public static string Body(string orderName, string address) => 
            $"Ваш заказ: '{orderName}' готов. Вы можете его получить в любой день с 9:00 до 21:00 " +
            $"по адресу: {address}.";
    }
}
