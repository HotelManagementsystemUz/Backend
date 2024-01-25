namespace Application.Common.Validators;

public static class OrderStatusValidator
{
    public static bool IsValid(this OrderStatus orderStatus)
        => orderStatus != null &&
        string.IsNullOrEmpty(orderStatus.Name);
    public static bool IsExist(this OrderStatus orderStatus, IEnumerable<OrderStatus> orderStatuses)
        => orderStatuses.Any(i => i.Name == orderStatus.Name &&
                                   i.Id != orderStatus.Id);
                                
}
