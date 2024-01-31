

using Application.DTOs.HotelDtos.Order;

namespace Application.Interfaces;

public interface IOrderService
{
    Task<List<OrderDto>> GetAllOrdersAsync();
    Task<OrderDto> GetOrderByIdAsync(int id);
    Task AddOrderAsync(AddOrderDto order);
    Task DeleteOrderAsync(int id);
    Task UpdateOrderAsync(UpdateOrderDto order);
    Task<List<OrderDto>> GetAllOrdersWithStatusAsync();

}
