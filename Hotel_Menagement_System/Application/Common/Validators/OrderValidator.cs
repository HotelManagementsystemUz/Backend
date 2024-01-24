

namespace Application.Common.Validators;

public static class OrderValidator
{
    public static bool IsValid(this Order order)
        => order != null &&
        order.AdminId >= 0 &&
        order.GuestId >= 0 &&
        order.StatusId > 0 &&
        order.StartDate >= order.EndDate;

    public static bool IsExist(this Order order, IEnumerable<Order> orders)
    {
        if (order == null || orders == null)
        {
            return false;
        }

        return orders.Any(i =>
            i.AdminId == order.AdminId &&
            i.GuestId == order.GuestId &&
            i.StatusId == order.StatusId &&
            i.StartDate == order.StartDate &&
            i.EndDate == order.EndDate);
    }

}
